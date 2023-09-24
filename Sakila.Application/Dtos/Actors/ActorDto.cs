using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakila.Application.Dtos.Common;

namespace Sakila.Application.Dtos.Actors
{
    public class ActorDto : BaseDto,IActorDto
    {
        public int Actor_id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
 
    }
}
