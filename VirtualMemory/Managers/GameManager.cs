using System;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using System.Configuration;
using System.IO;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Managers
{
	public class GameManager
	{
		private bool fmLoaded;
		private bool fmLoading;

		public GameManager ()
		{
			this.fmLoaded = false;
			this.fmLoading = false;
		}

		public bool FMLoaded {
			get { return fmLoaded; }
		}

		public bool FMLoading {
			get { return fmLoading; }
			set { fmLoading = value; }
		}

		public IVersion Version {
			get;
			private set;
		}

		#if LINUX
		// Finds the process and loads it in memory
		public bool findFMProcess ()
		{
			FMProcess fmProcess = new FMProcess ();
			Process[] fmProcesses = Process.GetProcessesByName ("fm");
			uint pid = fmProcesses.Length > 1 ? (uint)fmProcesses[0].Id : (uint)fmProcesses[0].Id;

			if (fmProcesses.Length > 0) {
				uint buffer;
				uint heap;
				uint endaddress;
				if (ProcessMemoryAPI.GetBaseAddress (pid, out buffer, out heap, out endaddress)) {
					fmProcess.Process = fmProcesses [0];
					fmProcess.BaseAddress = (int)buffer;
					fmProcess.HeapAddress = (int)heap;
					fmProcess.EndPoint = (int)endaddress;
					ProcessManager.fmProcess = fmProcess;

					// Search for the current version
					foreach (var versionType in Assembly.GetCallingAssembly().GetTypes().Where(t => typeof(IIVersion).IsAssignableFrom(t))) {
						if (versionType.IsInterface)
							continue;
						var instance = (IIVersion)Activator.CreateInstance (versionType);

						if (instance.SupportsProcess (fmProcess, null)) {
							Version = instance;
							break;
						}
					}
				}
				fmLoaded = (Version != null);
			}

			if (!fmLoaded) {
				int i;
				// Try to find info about the version
				// Lookup the objects in the memory
				for (i = fmProcess.BaseAddress; i < fmProcess.HeapAddress; i += 4) {
					int memoryAddress = ProcessManager.ReadInt32 (i);
					if (memoryAddress > fmProcess.BaseAddress && memoryAddress < fmProcess.EndPoint) {
						memoryAddress = ProcessManager.ReadInt32 (memoryAddress + 0x1C);
						if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
							continue;
						int xorValueOne = ProcessManager.ReadInt32 (memoryAddress + 0x2C + 0x4);
						int xorValueTwo = ProcessManager.ReadInt32 (memoryAddress + 0x2C);
						memoryAddress = xorValueTwo ^ xorValueOne;
						if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
							continue;
						memoryAddress = ProcessManager.ReadInt32 (memoryAddress + 0x54);
						if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
							continue;
						int numberOfObjects = ProcessManager.ReadArrayLength (memoryAddress);
						if (numberOfObjects != 7)
							continue;
						else
							Debug.WriteLine ("Found a candidate @ 0x{0:X}", i);
					} else
						continue;
				}
			}

			return fmLoaded;
		}
		#endif
		#if MAC
		public bool findFMProcess() {
			FMProcess fmProcess = new FMProcess ();
			Process[] fmProcesses = Process.GetProcessesByName ("fm");
			if (fmProcesses.Length > 0) {

				Process activeProcess = fmProcesses [0];
				fmProcess.Process = activeProcess;
				fmProcess.BaseAddress = activeProcess.MainModule.BaseAddress.ToInt32 ();
				fmProcess.EndPoint = ProcessManager.GetProcessEndPoint (activeProcess.Id);

				ProcessManager.fmProcess = fmProcess;

				// Search for the current version
				foreach (var versionType in Assembly.GetCallingAssembly().GetTypes().Where(t => typeof(IIVersion).IsAssignableFrom(t))) {
					if (versionType.IsInterface)
						continue;
					var instance = (IIVersion)Activator.CreateInstance (versionType);

					if (instance.SupportsProcess (fmProcess, null)) {
						Version = instance;
						break;
					}
				}

				fmLoaded = (Version != null);

				#region ObjectScanner
				if (!fmLoaded)
				{
					int i;
					// Try to find info about the version
					// Lookup the objects in the memory
					for (i = 0x32A0000; i < fmProcess.EndPoint; i += 4)
					{
						int cities = TryGetPointerObjects(i, 0x14, fmProcess);
						int clubs = TryGetPointerObjects(i, 0x1C, fmProcess);
						int leagues = TryGetPointerObjects(i, 0x24, fmProcess);
						int stadiums = TryGetPointerObjects(i, 0x8C, fmProcess);
						int teams = TryGetPointerObjects(i, 0xA4, fmProcess);
						int continents = TryGetPointerObjects(i, 0x2C, fmProcess);
						int countries = TryGetPointerObjects(i, 0x64, fmProcess);
						int persons = TryGetPointerObjects(i, 0x6C, fmProcess);

						if (continents == 7 && countries == 240 && (
							cities > 0 && clubs > 0 && leagues > 0 && stadiums > 0 &&
							teams > 0 && persons > 0
						))
						{
							Debug.WriteLine("Found a candidate @ 0x{0:X}", i);
						}
					}
				}
				#endregion
			}

			return fmLoaded;
		}
		#endif
		#if WINDOWS
		public bool findFMProcess() {
			FMProcess fmProcess = new FMProcess ();
			Process[] fmProcesses = Process.GetProcessesByName ("fm");

			if (fmProcesses.Length > 0) {
				Process activeProcess = fmProcesses [0];

				fmProcess.Pointer = ProcessMemoryAPI.OpenProcess (0x001F0FFF, 1, (uint)activeProcess.Id);
				fmProcess.EndPoint = ProcessManager.GetProcessEndPoint (fmProcess.Pointer);
				fmProcess.Process = activeProcess;
                fmProcess.BaseAddress = activeProcess.MainModule.BaseAddress.ToInt32();

				ProcessManager.fmProcess = fmProcess;
				fmProcess.VersionDescription = fmProcess.Process.MainModule.FileVersionInfo.ProductVersion;

				// Search for the current version
				foreach (var versionType in Assembly.GetCallingAssembly().GetTypes().Where(t => typeof(IIVersion).IsAssignableFrom(t))) {
					if (versionType.IsInterface)
						continue;
					var instance = (IIVersion)Activator.CreateInstance (versionType);

					if (instance.SupportsProcess (fmProcess, null)) {
						Version = instance;
						break;
					}
				}

				fmLoaded = (Version != null);

                if (!fmLoaded)
                {
                    int i;
                    // Try to find info about the version
                    // Lookup the objects in the memory
                    for (i = (fmProcess.BaseAddress + 0x1A8484E); i < fmProcess.EndPoint; i += 4)
                    {
                        int cities, clubs, leagues, stadiums, teams, continents, countries, persons;
                        string[] splitVersion = fmProcess.VersionDescription.Split('.');
                        if (splitVersion[0] == "14") {
                            cities = TryGetPointerObjects(i, 0x14, fmProcess);
                            clubs = TryGetPointerObjects(i, 0x1C, fmProcess);
                            leagues = TryGetPointerObjects(i, 0x24, fmProcess);
                            stadiums = TryGetPointerObjects(i, 0x8C, fmProcess);
                            teams = TryGetPointerObjects(i, 0xA4, fmProcess);
                            continents = TryGetPointerObjects(i, 0x2C, fmProcess);
                            countries = TryGetPointerObjects(i, 0x64, fmProcess);
                            persons = TryGetPointerObjects(i, 0x6C, fmProcess);
                        }
                        else
                        {
                            cities = TryGetPointerObjects(i, 0x10, fmProcess);
                            clubs = TryGetPointerObjects(i, 0x14, fmProcess);
                            leagues = TryGetPointerObjects(i, 0x18, fmProcess);
                            stadiums = TryGetPointerObjects(i, 0x4C, fmProcess);
                            teams = TryGetPointerObjects(i, 0x58, fmProcess);
                            continents = TryGetPointerObjects(i, 0x1C, fmProcess);
                            countries = TryGetPointerObjects(i, 0x38, fmProcess);
                            persons = TryGetPointerObjects(i, 0x3C, fmProcess);
                        }


                        if (continents == 7 && countries > 230 && countries < 250 && (
                            cities > 0 && clubs > 0 && leagues > 0 && stadiums > 0 &&
                            teams > 0 && persons > 0
                            ))
                        {
                            Debug.WriteLine("Found a candidate @ 0x{0:X}", i);
                        }
                    }
                }
			}
			return fmLoaded;
		}
		#endif

		public static int TryGetPointerObjects(int address, int offset, FMProcess fmProcess)
        {
			#if WINDOWS
            int memoryAddress = ProcessManager.ReadInt32(address);
            Debug.WriteLine("Base 0x{0:X} -> 0x{1:X}", address, memoryAddress);
            if (memoryAddress > fmProcess.BaseAddress && memoryAddress < fmProcess.EndPoint)
            {
                memoryAddress = ProcessManager.ReadInt32(memoryAddress);
                if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
                    return 0;

                string[] splitVersion = fmProcess.VersionDescription.Split('.');
                if (splitVersion[0] == "14")
                {
                    int xorValueOne = ProcessManager.ReadInt32(memoryAddress + offset + 0x4);
                    int xorValueTwo = ProcessManager.ReadInt32(memoryAddress + offset);
                    memoryAddress = xorValueTwo ^ xorValueOne;
                    if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
                        return 0;
                    memoryAddress = ProcessManager.ReadInt32(memoryAddress + 0x54);
                }
                else
                {
                    memoryAddress = ProcessManager.ReadInt32(memoryAddress + offset);
                    if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
                        return 0;
                    memoryAddress = ProcessManager.ReadInt32(memoryAddress + 0x40);
                }
                
                if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
                    return 0;

                int numberOfObjects = ProcessManager.ReadArrayLength(memoryAddress);
                return numberOfObjects;
            }
			#endif
			#if MAC
			int memoryAddress = ProcessManager.ReadInt32 (address + 0x1C);
			if (memoryAddress > fmProcess.BaseAddress && memoryAddress < fmProcess.EndPoint)
			{
				memoryAddress = ProcessManager.ReadInt32(memoryAddress);
				if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
					return 0;
				int xorValueOne = ProcessManager.ReadInt32(memoryAddress + offset + 0x4);
				int xorValueTwo = ProcessManager.ReadInt32(memoryAddress + offset);
				memoryAddress = xorValueTwo ^ xorValueOne;
				if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
					return 0;
				memoryAddress = ProcessManager.ReadInt32(memoryAddress + 0x54);
				if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
					return 0;
				int numberOfObjects = ProcessManager.ReadArrayLength(memoryAddress);
				return numberOfObjects;
			}
			#endif
            return 0;
        }
	}
}

