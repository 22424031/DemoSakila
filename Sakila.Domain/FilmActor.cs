﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Sakila.Domain;

public partial class FilmActor
{
    public ushort ActorId { get; set; }

    public ushort FilmId { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual Actor Actor { get; set; }

    public virtual Film Film { get; set; }
}