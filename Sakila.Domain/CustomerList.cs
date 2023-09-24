﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Sakila.Domain;

[Keyless]
public partial class CustomerList
{
    [Column("ID")]
    public ushort Id { get; set; }

    [Column("name")]
    [StringLength(91)]
    public string Name { get; set; }

    [Required]
    [Column("address")]
    [StringLength(50)]
    public string Address { get; set; }

    [Column("zip code")]
    [StringLength(10)]
    public string ZipCode { get; set; }

    [Required]
    [Column("phone")]
    [StringLength(20)]
    public string Phone { get; set; }

    [Required]
    [Column("city")]
    [StringLength(50)]
    public string City { get; set; }

    [Required]
    [Column("country")]
    [StringLength(50)]
    public string Country { get; set; }

    [Required]
    [Column("notes")]
    [StringLength(6)]
    public string Notes { get; set; }

    [Column("SID")]
    public byte Sid { get; set; }
}