using Microsoft.EntityFrameworkCore;
using TestConnectMySql.Models;

namespace TestConnectMySql.Database
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions o): base(o) { }

        DbSet<Student> Students { get; set; }   
    }
}
