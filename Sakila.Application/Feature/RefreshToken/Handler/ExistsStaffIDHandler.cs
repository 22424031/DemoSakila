using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sakila.Application.Contracts.Refresh_tokens;
using Sakila.Application.Feature.RefreshToken.Request;

namespace Sakila.Application.Feature.RefreshToken.Handler
{
    public class ExistsStaffIDHandler : IRequestHandler<ExistsStaffIDRequest, bool>
    {
        private readonly IRefresh_tokenRepository _refresh_TokenRepository;
        public ExistsStaffIDHandler(IRefresh_tokenRepository refresh_TokenRepository)
        {
            _refresh_TokenRepository = refresh_TokenRepository;
        }
        public async Task<bool> Handle(ExistsStaffIDRequest request, CancellationToken cancellationToken)
        {
            var result = await _refresh_TokenRepository.IsExists(request.id);
            return result;
        }
    }
}
