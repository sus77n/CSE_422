using Lab2_BuiNguyenHaiNgan_CSE422.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2_BuiNguyenHaiNgan_CSE422.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
         }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
