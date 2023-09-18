using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Domain.Common
{
    public class BaseDomainEntity
    {

        //public string CreatedBy { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public string DeleteBy { get; set; }
        //public DateTime DeleteOn { get; set; }
        //public string last_updateBy { get; set; }
        public DateTime last_update { get; set; }
    }
}
