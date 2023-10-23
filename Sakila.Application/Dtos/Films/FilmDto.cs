using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Dtos.Films
{
    public class FilmDto
    {
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
    }
}
