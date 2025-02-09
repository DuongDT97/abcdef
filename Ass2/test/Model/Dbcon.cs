using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace test.Model
{
    public class Dbcon : DbContext
    {
        public Dbcon(DbContextOptions<Dbcon> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Donhang> Donhangs { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Combos> Combos { get; set; }
        public DbSet<Hoadon> Hoadons { get; set; }
        public DbSet<Ngansach> Ngansaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Thiết lập quan hệ một-nhiều từ User tới GioHang
            modelBuilder.Entity<GioHang>()
                .HasOne(g => g.KhachHang)
                .WithMany(u => u.GioHangs)
                .HasForeignKey(g => g.KhachHangID);
               /* .OnDelete(DeleteBehavior.Cascade); // Điều này đảm bảo khi User bị xóa thì các GioHang liên quan cũng sẽ bị xóa*/
        }


    }
}
