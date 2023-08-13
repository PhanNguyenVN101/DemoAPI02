

namespace PhanNguyen_DemoAPI.Models
{
    public class DuAn:Entity
    {
        public string TenDA { get; set; }
        public ICollection<PhanCong>? PhanCongs { get; set; }
    }
}
