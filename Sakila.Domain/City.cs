﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Sakila.Domain;

public partial class City
{
    public ushort CityId { get; set; }

    public string City1 { get; set; }

    public ushort CountryId { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual ICollection<Address> Address { get; set; } = new List<Address>();

    public virtual Country Country { get; set; }
}