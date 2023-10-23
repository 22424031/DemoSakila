using Sakila.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sakila.Domain
{
    public class FilmActor:BaseDomainEntity
    {
        [Key]
        public int Actor_Id { get; set; }
        public int Film_Id { get; set; }

        public virtual Actor Actor { get; set; } = null!;
        public virtual Film Film { get; set; } = null!;
    }
}
