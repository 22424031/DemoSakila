using Sakila.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sakila.Domain
{
    public class City : BaseDomainEntity
    {
        //public City()
        //{
        //    Addresses = new HashSet<Address>();
        //}
        [Key]
        public int CityId { get; set; }

        public string city { get; set; } = null!;
        public ushort CountryId { get; set; }

       // public virtual Country Country { get; set; } = null!;
       // public virtual ICollection<Address> Addresses { get; set; }
    }
}
