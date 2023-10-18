using Sakila.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sakila.Domain
{
    public class staff : BaseDomainEntity
    {
        //public staff()
        //{
        //    Payments = new HashSet<Payment>();
        //    Rentals = new HashSet<Rental>();
        //}
        [Key]
        public int Staff_Id { get; set; }
        public string First_Name { get; set; } = null!;
        public string Last_Name { get; set; } = null!;
        public int Address_Id { get; set; }
        public byte[]? Picture { get; set; }
        public string? Email { get; set; }
        public int Store_Id { get; set; }
        public bool? Active { get; set; }
        public string Username { get; set; } = null!;
        public string? Password { get; set; }

        //public virtual Address Address { get; set; } = null!;
        //public virtual Store StoreNavigation { get; set; } = null!;
        //public virtual Store? Store { get; set; }
        //public virtual ICollection<Payment> Payments { get; set; }
        //public virtual ICollection<Rental> Rentals { get; set; }
    }
}
