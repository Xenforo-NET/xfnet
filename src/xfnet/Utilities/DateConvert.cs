using System;

namespace xfnet.Utilities
{
    public static class DateConvert
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        public static DateTime? XfDateToDateTime(XfModels.XfDate xfDate)
        {
            if (xfDate.Day == null || xfDate.Month == null || xfDate.Year == null) return null;
            return new DateTime(xfDate.Year.Value, xfDate.Month.Value, xfDate.Day.Value);
        }
    }
}
