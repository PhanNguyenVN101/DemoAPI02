

namespace PhanNguyen_DemoAPI.Models
{
    public class PhongBan : Entity
    {
        public string TenPB { get; set; }
        public ICollection<NhanVien>? NhanViens { get; set; }
    }
}
