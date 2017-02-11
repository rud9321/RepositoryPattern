using System.Data.Entity;
using WebAppRepo.Models;

namespace WebAppRepo.Entity
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<StudentClass> StudentClasses { get; set; }
    }
}