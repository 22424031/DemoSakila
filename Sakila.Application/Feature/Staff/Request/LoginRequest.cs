using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sakila.Application.Dtos.Staff;

namespace Sakila.Application.Feature.Staff.Request
{
    public class LoginRequest : IRequest<StaffDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
