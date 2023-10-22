using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sakila.Application.Contracts.Refresh_tokens;
using Sakila.Application.Dtos.RefreshTokens;
using Sakila.Application.Feature.RefreshToken.Request;
using Sakila.Domain;

namespace Sakila.Application.Feature.RefreshToken.Handler
{
    
    public class CreateTokenHandler : IRequestHandler<CreateTokenRequest, Refresh_tokenDto>
    {
        private readonly IRefresh_tokenRepository _refresh_TokenRepository;
        private readonly IMapper _mapper;
        public CreateTokenHandler(IRefresh_tokenRepository refresh_TokenRepository, IMapper mapper)
        {
            _refresh_TokenRepository = refresh_TokenRepository;
            _mapper = mapper;
        }

        public async Task<Refresh_tokenDto> Handle(CreateTokenRequest request, CancellationToken cancellationToken)
        {
            var refreshToken = await _refresh_TokenRepository.Add(_mapper.Map<refresh_token>(request.refresh_TokenDto));
            await _refresh_TokenRepository.SaveChange();
            if (refreshToken is not null)
            {
                return _mapper.Map<Refresh_tokenDto>(refreshToken);
            }
            return null;
        }
    }
}
