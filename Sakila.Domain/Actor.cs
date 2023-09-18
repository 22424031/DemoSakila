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
        public int Actor_id { get; set; }
        public string First_Name {get;set;}
        public string Last_Name { get; set; }
      
    }
}
