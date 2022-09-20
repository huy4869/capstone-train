using Microsoft.EntityFrameworkCore;
using TestConnection3.Models;

namespace TestConnection3.DBContexts
{
    public class MyDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public MyDBContext(DbContextOptions<MyDBContext> o) : base(o) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  
            // Map entities to tables
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Mentor>().ToTable("Mentor");
            // Configure primary key
            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Mentor>().HasKey(m => m.Id);
            // Configure columns
            modelBuilder.Entity<Student>().Property(u => u.Id)
                .HasColumnType("nvarchar(100)").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Student>().Property(u => u.FullName)
               .HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Student>().Property(u => u.Age)
               .HasColumnType("int").IsRequired();
            modelBuilder.Entity<Student>().Property(u => u.Gender)
               .HasColumnType("nvarchar(10)").IsRequired();
            modelBuilder.Entity<Student>().Property(u => u.Address)
               .HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Student>().Property(u => u.Mentor_Id)
               .HasColumnType("int").IsRequired();

            modelBuilder.Entity<Mentor>().Property(u => u.Id)
                .HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Mentor>().Property(u => u.FullName)
               .HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Mentor>().Property(u => u.Subject)
               .HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Mentor>().Property(u => u.Email)
               .HasColumnType("nvarchar(100)").IsRequired();

            // Configure relationships
            modelBuilder.Entity<Student>().HasOne<Mentor>().WithMany().
                HasPrincipalKey(mt => mt.Id).HasForeignKey(s => s.Mentor_Id);
        }
    }
}
