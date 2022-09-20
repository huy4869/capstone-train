using Microsoft.EntityFrameworkCore;
using TestConnectDataAnnotation.Models;

namespace TestConnectDataAnnotation.MyContext
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> o) : base(o) { }

        public DbSet<Class> Classes { get; set; }   
        public DbSet<Student> Students { get; set; }
    }
}
