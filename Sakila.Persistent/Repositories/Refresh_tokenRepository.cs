using Microsoft.EntityFrameworkCore;
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
        private SakilaContext _dbContext;
        public Refresh_tokenRepository(SakilaContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task CreateToken(string userName, string password, string token)
        { 
            var user = await _dbContext.staff.FirstOrDefaultAsync(x => x.Username.ToLower() == userName.ToLower() && password.ToLower() == x.Password.ToLower());
            if(user == null)
            {

            }
        }
        public async Task<bool> IsExists(int id)
        {
            var isExist = await _dbContext.refresh_token.AsNoTracking().FirstOrDefaultAsync(x => x.Staff_Id == id);
            return isExist != null? true:false;
        }
        public async Task SaveChange()
        {
            await _dbContext.SaveChangeAsync("system");
        }
    }
}
