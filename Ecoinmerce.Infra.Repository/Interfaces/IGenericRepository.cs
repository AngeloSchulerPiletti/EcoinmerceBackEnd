namespace Ecoinmerce.Infra.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        public void Delete(int id);
        public bool SaveChanges();
        public Task<bool> SaveChangesAsync();
    }
}
