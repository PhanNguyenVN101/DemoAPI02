namespace PhanNguyen_DemoAPI.Models.ResponseModels
{
    public class PhanCongResponse
    {
        public string? NhanVienId { get; set; }
        public string? DuAnId { get; set; }

        public DateTimeOffset NgayBD { get; set; }
        public DateTimeOffset NgayKT { get; set; }
    }
}
