using Sakila.Application.Contracts.Refresh_tokens;
using Sakila.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Persistent.Repositories
{
    public class Refresh_tokenRepository : GenericRepository<refresh_token>, IRefresh_tokenRepository
    {
    }
}
