using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sakila.Application.Feature.RefreshToken.Request;
using AutoMapper;
using Sakila.Application.Contracts.Refresh_tokens;
using Sakila.Application.Contracts.Staffs;
using Sakila.Application.Dtos.Staff;
using Sakila.Domain;

namespace Sakila.Application.Feature.RefreshToken.Handler
{
    public class UpdateTokenHandler : IRequestHandler<UpdateTokenRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRefresh_tokenRepository _refresh_TokenRepository;
        public UpdateTokenHandler(IMapper mapper, IRefresh_tokenRepository refresh_TokenRepository)
        {
            _mapper = mapper;
            _refresh_TokenRepository = refresh_TokenRepository;
        }

        public async Task<bool> Handle(UpdateTokenRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<refresh_token>(request.Refresh_token);
            //var Isuser = await _refresh_TokenRepository.Exists(request.Refresh_token.Staff_Id);
        
            await _refresh_TokenRepository.Update(dto);
            await _refresh_TokenRepository.SaveChange();
            return true;
            
                   
        }
    }
}
