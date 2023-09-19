using Sakila.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Domain
{
    public class Actor : BaseDomainEntity
    {
        [Key]
        public int actor_id { get; set; }
        public string first_name {get;set;}
        public string last_name { get; set; }

    }
}
