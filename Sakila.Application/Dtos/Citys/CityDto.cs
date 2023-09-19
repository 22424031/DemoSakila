using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Dtos.Citys
{
    public class CityDto
    {
        public int city_id { get; set; }
        public string city { get; set; }
        public int country_id { get; set; }
        public DateTime Last_Update { get; set; }
    }
}
