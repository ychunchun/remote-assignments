using Microsoft.EntityFrameworkCore;
using Assignment_1.Models;  
// 假設 User 類型定義在 Assignment_1.Models 命名空間中


namespace Assignment_1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> user { get; set; }
    }
}
