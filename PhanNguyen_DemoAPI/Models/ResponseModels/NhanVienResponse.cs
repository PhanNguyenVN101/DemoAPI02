
using PhanNguyen_DemoAPI.Models;

namespace PhanNguyen_DemoAPI.ResponseModels
{
    public class NhanVienResponse
    {
        public string Id { get; set; }
        public string HoTen { get; set; }
        public string? GioiTinh { get; set; }
        public string? PhongBanId { get; set; }
    }
}
