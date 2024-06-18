using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Entity.Poco;

namespace ECommerceAPI.Business.Abstract
{
    public interface ICategoryServices : IGenericServices<Category>
    {
        Task<Category> GetAsync(Expression<Func<Category, bool>> Filter, params string[] IncludeProperties);
    }


}
