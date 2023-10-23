using Sakila.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sakila.Domain
{
    public class Actor  : BaseDomainEntity
    {
        //public Actor()
        //{
        //    FilmActors = new HashSet<FilmActor>();
        //}
        [Key]
        public int Actor_Id { get; set; }
        public string First_Name { get; set; } = null!;
        public string Last_Name { get; set; } = null!;
     

        public virtual ICollection<FilmActor> FilmActors { get; set; }
    }
}
