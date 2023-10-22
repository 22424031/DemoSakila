using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Dtos.Common
{
    public class BaseTokenDto
    {
        public string? Token { get; set; }
        public string? TokenRefresh { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
