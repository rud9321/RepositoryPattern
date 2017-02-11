using System.Collections.Generic;

namespace WebAppRepo.DAL
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(int id);
        void Insert(TEntity model);
        void Delete(int id);
        void Update(TEntity model);
        void Commit();
    }
}
