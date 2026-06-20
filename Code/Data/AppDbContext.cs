using BanhNgotApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BanhNgotApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
    }
}
