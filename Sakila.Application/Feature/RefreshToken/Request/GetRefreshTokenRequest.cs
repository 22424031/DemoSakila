using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sakila.Application.Dtos.Common;

namespace Sakila.Application.Feature.RefreshToken.Request
{
    public class GetRefreshTokenRequest : IRequest<BaseTokenDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string key { get; set; }
    }
}
