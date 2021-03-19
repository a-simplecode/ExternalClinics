using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace ExternalClinics
{
    public static class StringExtension
    {
        public static string ToQueryString(this string str)
        {
            if (str == null || str.Trim() == "")
                return "null";
            return "'" + str.Replace("'", "''").Trim() + "'";
        }
        public static string ToQueryNumeric(this int myValue)
        {
            if (myValue == 0)
                return "null";
            return myValue.ToString();
        }
        public static string ToQueryNumeric(this double myValue, int Rounding = -1)
        {
            if (myValue == 0)
                return "null";
            if (Rounding > -1)
                return Math.Round(myValue, Rounding).ToString();

            return myValue.ToString();
        }
        public static string ToQueryBit(this bool myValue)
        {
            if (myValue)
                return "1";
            else
                return "0";
        }
        public static string ToNullableDatetimeMMddyyHHmmss(this DateTime? myValue)
        {
            if (!myValue.HasValue)
                return "null";
            else return "'" + myValue.Value.ToString("MM/dd/yyyy HH:mm") + "'";

        }
    }

}
