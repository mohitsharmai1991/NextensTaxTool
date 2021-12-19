using System;

namespace NextensTaxTool.Common
{
    public static class General
    {
        public static bool IsChangedinComparedPercent(long previous, long current, double comparePercent)
        {
            if (previous == 0 || current == 0)
            {
                return false;
            }

            return PercentChange(previous, current) >= comparePercent;
        }

        public static double PercentChange(long previous, long current)
        {
            return Math.Round((double)Math.Abs(current - previous) / previous, 2) * 100;
        }
    }
}
