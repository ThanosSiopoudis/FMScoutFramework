using System;

namespace FMScoutFramework.Core.Attributes
{
	internal class MemoryAddressAttribute : Attribute
	{
		public int CountLength { get; set; }
		public int BytesToSkip { get; set; }
		public int ObjectOffset { get; set; }

		public MemoryAddressAttribute(int countLength, int bytesToSkip, int objectOffset = 0x00)
		{
			this.CountLength = countLength;
			this.BytesToSkip = bytesToSkip;
			this.ObjectOffset = objectOffset;
		}

		public MemoryAddressAttribute() {}
	}
}

