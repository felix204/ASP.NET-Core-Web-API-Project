using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Business.Abstract
{
    public interface IGenericServices<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties);

        Task<T> AddAsync(T Entity);

        Task UpdateAsync(T Entity);

        Task DeleteAsync(T Entity);
    }
}
