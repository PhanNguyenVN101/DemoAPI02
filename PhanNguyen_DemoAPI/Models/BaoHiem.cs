
namespace PhanNguyen_DemoAPI.Models
{
    public class BaoHiem : Entity
    {
        public string TenBH { get; set; }
        public string ? NhanVienId { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
