namespace FMScoutFramework.Core.Entities.GameVersions
{
	public interface IVersion
	{
		string Description { get; }
        string MainVersionNumber { get; }
		IVersionMemoryAddresses MemoryAddresses { get; }
		IVersionPersonEnumPointers PersonEnum { get; }
		IPersonVersionOffsets PersonOffsets { get; }
        OperatingSystemEnum OperatingSystem
        {
            get;
        }
    }

	internal interface IIVersion : IVersion
	{
		bool SupportsProcess(FMProcess process, byte[] context);        
	}
}

