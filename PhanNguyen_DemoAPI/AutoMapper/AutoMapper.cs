using AutoMapper;
using PhanNguyen_DemoAPI.Models;
using PhanNguyen_DemoAPI.Models.ResponseModels;
using PhanNguyen_DemoAPI.ResponseModels;

namespace PhanNguyen_DemoAPI.AutoMapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            MapNhanVien();
            MapDuAn();
            MapPhanCong();
            MapBaoHiem();
            MapPhongBan();
        }
        private void MapNhanVien()
        {
            CreateMap<NhanVien,NhanVienResponse>().ReverseMap();
        }
        private void MapDuAn()
        {
            CreateMap<DuAn, DuAnResponse>().ReverseMap();
        }
        private void MapPhanCong()
        {
            CreateMap<PhanCong, PhanCongResponse>().ReverseMap();
        }
        private void MapBaoHiem()
        {
            CreateMap<BaoHiem, BaoHiemResponse>().ReverseMap();
        }
        private void MapPhongBan()
        {
            CreateMap<PhongBan, PhongBanResponse>().ReverseMap();
        }
    }
}
