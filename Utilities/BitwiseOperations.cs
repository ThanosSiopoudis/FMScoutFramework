using System;

namespace FMScoutFramework.Core.Utilities
{
	public class BitwiseOperations
	{
		public static uint ror(uint value, int bits)
		{
			return (value >> bits) | (value << (32 - bits));
		}

		public static uint ror_short(uint value, int bits)
		{
			return ((value >> bits) | (value << (16 - bits)) & 0xFFFF);
		}

		public static uint rol(uint value, int bits)
		{
			return (value << bits) | (value >> (32 - bits));
		}

		public static uint rol_short(uint value, int bits)
		{
			return ((value << bits) | (value >> (16 - bits)) & 0xFFFF) & 0xffff;
		}
	}
}

