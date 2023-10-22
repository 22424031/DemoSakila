using Sakila.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Contracts.Refresh_tokens
{
    public interface IRefresh_tokenRepository : IGenericRepository<refresh_token>
    {
        Task CreateToken(string userName,string password,string token);
        Task SaveChange();
        Task<bool> IsExists(int id);
    }
}
