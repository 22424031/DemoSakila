﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Dtos.Actors
{
    public class ActorDto
    {
        public int Actor_id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Last_update { get; set; }
    }
}
