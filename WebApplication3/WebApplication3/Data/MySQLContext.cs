using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

public class MySQLContext : DbContext
{
    public DbSet<WebApplication3.Models.City> City { get; set; }
    public DbSet<WebApplication3.Models.Country> Country { get; set; }
    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Use Fluent API to configure  

        modelBuilder.Entity<Country>().ToTable("country");
        modelBuilder.Entity<Country>().HasKey(co => co.countryCode).HasName("PK_CountryCode");//create key
        modelBuilder.Entity<Country>().HasIndex(co => co.name).IsUnique().HasDatabaseName("Idx_Name");//create index
        // Configure columns
        modelBuilder.Entity<Country>().Property(co => co.countryCode).HasColumnType("char(3)").IsRequired();
        modelBuilder.Entity<Country>().Property(co => co.name).HasColumnType("char(52)").IsRequired();
        modelBuilder.Entity<Country>().Property(co => co.continent).HasColumnType("nvarchar(100)").IsRequired(false);
        modelBuilder.Entity<Country>().Property(co => co.region).HasColumnType("char(26)").IsRequired(false);
        modelBuilder.Entity<Country>().Property(co => co.surfaceArea).HasColumnType("decimal(10,2)");
        modelBuilder.Entity<Country>().Property(co => co.indepYear).HasColumnType("smallint");
        modelBuilder.Entity<Country>().Property(co => co.population).HasColumnType("int");
        modelBuilder.Entity<Country>().Property(co => co.lifeExpectancy).HasColumnType("decimal(3,1)");
        modelBuilder.Entity<Country>().Property(co => co.GNP).HasColumnType("decimal(10,2)");
        modelBuilder.Entity<Country>().Property(co => co.GNPOld).HasColumnType("decimal(10,2)");
        modelBuilder.Entity<Country>().Property(co => co.localName).HasColumnType("varchar(45)").IsRequired(false);
        modelBuilder.Entity<Country>().Property(co => co.governmentForm).HasColumnType("char(45)").IsRequired(false);
        modelBuilder.Entity<Country>().Property(co => co.headOfState).HasColumnType("char(45)").IsRequired(false);
        modelBuilder.Entity<Country>().Property(co => co.capital).HasColumnType("int");
        modelBuilder.Entity<Country>().Property(co => co.code2).HasColumnType("char(2)").IsRequired(false);

        modelBuilder.Entity<City>().ToTable("city");
        modelBuilder.Entity<City>().HasKey(ci => ci.Id).HasName("PK_city");
        modelBuilder.Entity<City>().HasIndex(ci => ci.name).HasDatabaseName("Idx_FirstName");
        // Configure columns  
        modelBuilder.Entity<City>().Property(ci => ci.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
        modelBuilder.Entity<City>().Property(ci => ci.name).HasColumnType("char(35)").IsRequired();
        modelBuilder.Entity<City>().Property(ci => ci.countryCode).HasColumnType("char(3)").IsRequired();
        modelBuilder.Entity<City>().Property(ci => ci.district).HasColumnType("char(20)").IsRequired(false);
        modelBuilder.Entity<City>().Property(ci => ci.population).HasColumnType("int");

        // Configure relationships  
        modelBuilder.Entity<City>().HasOne<Country>().WithMany().HasPrincipalKey(co => co.countryCode).HasForeignKey(ci => ci.countryCode).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_city_country");
    
    }
}
