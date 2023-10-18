using Sakila.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Dtos.Staff
{
    public class StaffDto : BaseDto
    {
        public int Staff_Id { get; set; }
        public string First_Name { get; set; } = null!;
        public string Last_Name { get; set; } = null!;
        public int Address_Id { get; set; }
        public byte[]? Picture { get; set; }
        public string? Email { get; set; }
        public int Store_Id { get; set; }
        public bool? Active { get; set; }
     
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
