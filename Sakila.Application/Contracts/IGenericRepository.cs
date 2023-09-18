using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task<bool> Exists(int id);
        Task<T> Get(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task Update(T entity);

    }
}
