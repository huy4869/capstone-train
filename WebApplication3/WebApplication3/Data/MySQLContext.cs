using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

    public class MySQLContext : DbContext
    {
        public MySQLContext (DbContextOptions<MySQLContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication3.Models.City> City { get; set; }
    }
