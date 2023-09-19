using Sakila.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Domain
{
    public class City : BaseDomainEntity
    {
        [Key]
        public int city_id { get; set; }
        public string city { get; set; }
        public int country_id { get; set; }
    }
}
