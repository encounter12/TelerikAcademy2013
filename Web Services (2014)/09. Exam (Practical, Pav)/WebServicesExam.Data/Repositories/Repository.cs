namespace WebServicesExam.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext dbContext;
        private IDbSet<T> dbSet;

        public Repository(DbContext context)
        {
            this.dbContext = context;
            this.dbSet = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.dbSet;
        }

        public T Find(object id)
        {
            return this.dbSet.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);

            return entity;
        }

        public T Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);

            return entity;
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.dbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            entry.State = state;
        }
    }
}
