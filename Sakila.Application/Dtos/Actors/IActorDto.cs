﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Dtos.Actors
{
    public interface IActorDto
    {
        public int Actor_id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Last_Update { get; set; }
    }
}
