using Microsoft.EntityFrameworkCore;
using Sakila.Application.Contracts.Staffs;
using Sakila.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Persistent.Repositories
{
    public class StaffRepository : GenericRepository<staff>, IStaffRepository
    {
        private readonly SakilaContext _contextSakila;
        public StaffRepository(SakilaContext dbContext) : base(dbContext)
        {
            _contextSakila = dbContext;
        }
        public async Task SaveChange()
        {
            await _contextSakila.SaveChangeAsync("system");
        }
        public async Task<staff> Login(string userName, string password)
        {
            var user = await _contextSakila.staff
                .FirstOrDefaultAsync(x => x.Username.ToLower() == userName.ToLower() && x.Password!.ToLower() == password.ToLower());
            return user;
        }
    }
}
