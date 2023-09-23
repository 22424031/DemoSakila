using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Dtos.Citys
{
    public interface ICityDto
    {
        public int city_id { get; set; }
        public string city { get; set; }
        public int country_id { get; set; }
   
    }
}
