using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;

namespace FMScoutFramework.Core.Entities
{
	public class Global
	{
		private readonly IVersion _version;
		public Global (IVersion version)
		{
			_version = version;
		}

		public DateTime InGameDate {
			#if MAC
			get { return ProcessManager.ReadDateTime(_version.MemoryAddresses.CurrentDateTime); }
			#endif
			#if WINDOWS || LINUX
			get { return ProcessManager.ReadDateTime (ProcessManager.fmProcess.BaseAddress + _version.MemoryAddresses.CurrentDateTime); }
			#endif
		}
	}

	public enum DatabaseModeEnum { Realtime, Cached }

    public enum OperatingSystemEnum { Windows, Mac, Linux }
}

