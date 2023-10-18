using Sakila.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Dtos.RefreshTokens
{
    public class refresh_tokenDto : BaseDto
    {
        public int Staff_Id { get; set; }
        public string token { get; set; } = null!;
        public string? client_id { get; set; }
    }
}
