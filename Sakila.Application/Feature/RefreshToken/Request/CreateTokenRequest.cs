using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sakila.Application.Dtos.RefreshTokens;


namespace Sakila.Application.Feature.RefreshToken.Request
{
    public class CreateTokenRequest : IRequest<Refresh_tokenDto>
    {
        public Refresh_tokenDto refresh_TokenDto { get; set; }
    }
}
