using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sakila.Application.Dtos.RefreshTokens;
using Sakila.Application.Dtos.Staff;

namespace Sakila.Application.Feature.RefreshToken.Request
{
    public class UpdateTokenRequest : IRequest<bool>
    {
        public refresh_tokenDto Refresh_token { get; set; }
       
    }
}
