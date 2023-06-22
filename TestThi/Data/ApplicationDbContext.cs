
using Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Test.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<LopHoc> LopHocs {get; set;}
        public DbSet<SinhVien> SinhViens {get; set;}
        public DbSet<Users> Users {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("users").HasData(new Users()
            {
                Id = 1,
                Username = "Admin",
                Password = "123456",
                Address = "Thanh Hoa City",
                FullName = "Lê Thị Hòa"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}