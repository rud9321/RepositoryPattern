using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebAppRepo.Entity;

namespace WebAppRepo.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal readonly DataBaseContext _context;
        internal DbSet<TEntity> Dbset;
        public Repository(DataBaseContext context)
        {
            _context = context;
            Dbset = _context.Set<TEntity>();
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = GetByID(id);
            Dbset.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Dbset;
        }

        public TEntity GetByID(int id)
        {
            return Dbset.Find(id);
        }

        public void Insert(TEntity model)
        {
            Dbset.Add(model);
            _context.SaveChanges();
        }

        public void Update(TEntity model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        private void Dispose(bool v)
        {
            if (!this.disposed)
            {
                if (v)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}