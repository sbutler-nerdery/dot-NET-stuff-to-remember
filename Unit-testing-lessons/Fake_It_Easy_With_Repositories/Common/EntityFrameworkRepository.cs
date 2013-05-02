using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Ninject;

namespace Common
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        private readonly EntityFrameworkUnitOfWork _unitOfWork;
        private DbSet<T> DbSet { get; set; }

        [Inject]
        public EntityFrameworkRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (EntityFrameworkUnitOfWork)unitOfWork;
            DbSet = _unitOfWork.CreateDbSet<T>();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<T> GetAll(params string[] includes)
        {
            return DbSet.IncludeAll(includes);
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return DbSet.IncludeAll(includes);
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void SubmitChanges()
        {
            _unitOfWork.SubmitChanges();
        }
    }
}
