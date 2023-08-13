

using PhanNguyen_DemoAPI.ResponseModels;

namespace PhanNguyen_DemoAPI.Models
{
    public class NhanVien : Entity
    {
        public string HoTen { get; set; }
        public string? GioiTinh { get; set; }

        public string? PhongBanId { get; set; }

        public PhongBan PhongBan { get; set; }
        public ICollection<BaoHiem> ? BaoHiems { get; set; }
        public ICollection<PhanCong> ? PhanCongs { get; set; }
    }
}
