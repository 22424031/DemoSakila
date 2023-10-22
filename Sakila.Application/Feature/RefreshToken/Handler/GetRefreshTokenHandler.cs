using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sakila.Application.Dtos.Common;
using Sakila.Application.Feature.RefreshToken.Request;
using Sakila.Application.Ententions;
using Sakila.Application.Contracts.Staffs;
using Sakila.Application.Contracts.Refresh_tokens;

namespace Sakila.Application.Feature.RefreshToken.Handler
{
    public class GetRefreshTokenHandler : IRequestHandler<GetRefreshTokenRequest, BaseTokenDto>
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IRefresh_tokenRepository _refresh_TokenRepository;
        public GetRefreshTokenHandler(IStaffRepository staffRepository, IRefresh_tokenRepository refresh_TokenRepository)
        {
            _staffRepository = staffRepository;
            _refresh_TokenRepository = refresh_TokenRepository;
        }
        public async Task<BaseTokenDto> Handle(GetRefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var baseToken = new BaseTokenDto();
            string userNameDecode = EnCryptExtension.Decrypt(request.UserName, request.key);
            string passDecode = EnCryptExtension.Decrypt(request.Password, request.key);
            var user = await _staffRepository.Login(userNameDecode, passDecode);
            if(user is null)
            {
                return null;
            }
            var staff = await _refresh_TokenRepository.Get(user.Staff_Id);
            if(staff is not null)
            {
                baseToken.TokenRefresh = staff.token;
                return baseToken;
            }
            return null;
        }
    }
}
