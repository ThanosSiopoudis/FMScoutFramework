using System;

namespace FMScoutFramework.Core.Converters
{
	public static class DateConverter
	{
		public static DateTime FromFmDateTime(int days, int year)
		{
			DateTime time = new DateTime (year, 1, 1);
			return time.AddDays ((double)days);
		}

		public static int ToFmDateTime(DateTime date)
		{
			int year = date.Year;
			int days = (date.DayOfYear - 1);
			return ((days << 0x10) + year);
		}
	}
}

