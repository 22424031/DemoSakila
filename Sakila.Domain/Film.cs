using Sakila.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sakila.Domain
{
    public class Film : BaseDomainEntity
    {
        //public Film()
        //{
        //    FilmActors = new HashSet<FilmActor>();
        //    FilmCategories = new HashSet<FilmCategory>();
        //    Inventories = new HashSet<Inventory>();
        //}
        [Key]
        public int Film_Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public short? Release_Year { get; set; }
        public byte Language_Id { get; set; }
        public byte? Original_Language_Id { get; set; }
        public byte Rental_Duration { get; set; }
        public decimal Rental_Rate { get; set; }
        public int? Length { get; set; }
        public decimal Replacement_Cost { get; set; }
        public string? Rating { get; set; }
     //   public DateTime LastUpdate { get; set; }

        //public virtual Language Language { get; set; } = null!;
        //public virtual Language? OriginalLanguage { get; set; }
        //public virtual ICollection<FilmActor> FilmActors { get; set; }
        //public virtual ICollection<FilmCategory> FilmCategories { get; set; }
        //public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
