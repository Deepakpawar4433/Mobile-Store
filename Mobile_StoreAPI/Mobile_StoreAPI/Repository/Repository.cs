using Microsoft.EntityFrameworkCore;
using Mobile_StoreAPI.Models;
using Mobile_StoreAPI.Repository.IRepository;

namespace Mobile_StoreAPI
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntityModel, new()
    {
        private readonly MobilePhoneStoreProjectContext _dbContext;
        private bool disposed = false;

        protected DbSet<TEntity> DbSet;

        public Repository(MobilePhoneStoreProjectContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = this._dbContext.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            Save();
        }
        public async Task AddAll(List<TEntity> list)
        {
            await DbSet.AddRangeAsync(list);
        }

        public void Delete(TEntity entity)
        {
            try
            {
                DbSet?.Remove(entity);
                Save();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"{ex.Message} {ex.StackTrace}");
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException("Entity not found");
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
            Save();
        }

        private void Save()
        {
            this._dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Cleanup
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }

        public object GetById(int? saleId)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> Table
        {
            get
            {
                return this.DbSet;
            }
        }
    }
}