using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Common
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        [Inject]
        public EntityFrameworkUnitOfWork(DbContext container)
        {
            Container = container;
        }

        public DbContext Container { get; private set; }

        public bool UseSerializableEntities
        {
            get { return !Container.Configuration.ProxyCreationEnabled; }
            set { Container.Configuration.ProxyCreationEnabled = !value; }
        }

        public void Dispose() { }

        public void SubmitChanges()
        {
            Container.SaveChanges();
        }

        internal DbSet<TEntity> CreateDbSet<TEntity>() where TEntity : class
        {
            return Container.Set<TEntity>();
        }
    }
}
