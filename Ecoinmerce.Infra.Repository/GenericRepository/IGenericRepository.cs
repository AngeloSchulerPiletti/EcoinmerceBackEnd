namespace Ecoinmerce.Infra.Repository.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetById(uint id);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        public void Delete(uint id);
        public bool SaveChanges();
        public Task<bool> SaveChangesAsync();
    }
}
