using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astec.Model.Abstract
{
    public interface IAuditable
    {
        bool? STATUS { get; set; }
        string DESCRIPTION { get; set; }
        bool? SYNC { get; set; }
        DateTime? DATE_SYNC { get; set; }
        string ACC_ID { get; set; }
        string ACTION { get; set; }
        DateTime? DATE_ACTION { get; set; }
        string STATION_ACTION { get; set; }
        bool? DELETE { get; set; }
        string ZONE_SYNCHRONIZED { get; set; }
    }
}
