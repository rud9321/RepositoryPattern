using System;
using WebAppRepo.Entity;
using WebAppRepo.Models;

namespace WebAppRepo.DAL
{
    public class UnitOfWork
    {
        private DataBaseContext context = new DataBaseContext();

        private Repository<Student> studentRepository;
        private Repository<StudentClass> studentClassRepository;
        
        public Repository<Student> StudentRepository
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new Repository<Student>(context);
                }
                return studentRepository;
            }
        }
        public Repository<StudentClass> StudentClassRepository
        {
            get
            {

                if (this.studentClassRepository == null)
                {
                    this.studentClassRepository = new Repository<StudentClass>(context);
                }
                return studentClassRepository;
            }
        }        

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
