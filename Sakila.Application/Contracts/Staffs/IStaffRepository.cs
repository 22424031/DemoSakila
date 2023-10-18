using Sakila.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Contracts.Staffs
{
    public interface IStaffRepository : IGenericRepository<staff>
    {
        Task<staff> Login(string userName, string password);
    }
}
