using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        //IQueryable<T> GetAll(params string[] includes);
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        void Insert(T entity);
        void Delete(T entity);
        void SubmitChanges();
    }
}
