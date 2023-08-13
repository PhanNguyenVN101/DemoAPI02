using Microsoft.EntityFrameworkCore;
using PhanNguyen_DemoAPI.Models;

namespace PhanNguyen_DemoAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> opt):base(opt) 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];
            return strConn;
        }
        #region DbSet
        public DbSet<PhongBan> ? PhongBans { get; set; }
        public DbSet<NhanVien> ? NhanViens { get; set; }
        public DbSet<BaoHiem> ? BaoHiems { get; set; }
        public DbSet<PhanCong> ? PhanCongs { get; set; }
        public DbSet<DuAn> ? DuAns { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Many to Many relation between NhanVien and DuAn
            modelBuilder.Entity<PhanCong>()
                    .HasKey(t => new { t.NhanVienId, t.DuAnId });
            modelBuilder.Entity<PhanCong>()
                    .HasOne(t => t.NhanVien)
                    .WithMany(t => t.PhanCongs)
                    .HasForeignKey(f => f.NhanVienId);
            modelBuilder.Entity<PhanCong>()
                    .HasOne(t => t.DuAn)
                    .WithMany(t => t.PhanCongs)
                    .HasForeignKey(f => f.DuAnId);


        }

    }
}
