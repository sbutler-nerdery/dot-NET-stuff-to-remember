using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniprofiler.CodeFirst.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params string[] includes);
        void Insert(T entity);
        void Delete(T entity);
        void SubmitChanges();
    }
}
