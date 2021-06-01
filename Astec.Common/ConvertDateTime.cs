using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astec.Common
{
    public class ConvertDateTime
    {
        public DateTime? ConvertStringToDate(string date1)
        {
            var split = date1.Split('/');
            var t = split[2] + "-" + split[1] + "-" + split[0];
            DateTime? date2 = DateTime.Parse(t);
            return date2;
        }
        public TimeSpan ConvertStringToHour(string time1)
        {
            string[] split = time1.Split(':');
            string t = split[0] + ":" + split[1];
            TimeSpan time2 = TimeSpan.Parse(t);
            return time2;
        }
        public string ConvertStringToDateMonth(string date)
        {
            var split = date.Split('/');
            var t = split[0] + "/" + split[1];
            return t;
        }
        public string ConvertStringToDateMonth1(string date)
        {
            var split = date.Split('-');
            var t = split[2] + "/" + split[1];
            return t;
        }
    }
}
