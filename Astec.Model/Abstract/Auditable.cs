using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astec.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public bool? STATUS { get; set; }
        public string DESCRIPTION { get; set; }
        public bool? SYNC { get; set; }
        public DateTime? DATE_SYNC { get; set; }
        public string ACC_ID { get; set; }
        public string ACTION { get; set; }
        public DateTime? DATE_ACTION { get; set; }
        public string STATION_ACTION { get; set; }
        public bool? DELETE { get; set; }
        public string ZONE_SYNCHRONIZED { get; set; }
    }
}
