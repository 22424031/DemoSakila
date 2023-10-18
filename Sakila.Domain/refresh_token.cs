using Sakila.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sakila.Domain
{
    public class refresh_token : BaseDomainEntity
    {
        //public staff()
        //{
        //    Payments = new HashSet<Payment>();
        //    Rentals = new HashSet<Rental>();
        //}
        [Key]
        public int Staff_Id { get; set; }
        public string token { get; set; } = null!;
        public string? client_id { get; set; }
        //public virtual Address Address { get; set; } = null!;
        //public virtual Store StoreNavigation { get; set; } = null!;
        //public virtual Store? Store { get; set; }
        //public virtual ICollection<Payment> Payments { get; set; }
        //public virtual ICollection<Rental> Rentals { get; set; }
    }
}
