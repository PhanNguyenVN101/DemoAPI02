using AutoMapper;
using PhanNguyen_DemoAPI.Models;
using PhanNguyen_DemoAPI.Repositories;

namespace PhanNguyen_DemoAPI.Services
{
    public interface INhanVienService
    {
        public Task<ICollection<NhanVien>> GetAllNhanViensAsync();
        public Task<NhanVien> CreateNhanVienAsync(NhanVien model);
        public Task<NhanVien> UpdateNhanVienAsync(NhanVien model);
        public Task<NhanVien> DeleteNhanVienAsync(string id);
    }
    public class NhanVienService : INhanVienService
    {
        private readonly IMapper _mapper;
        private readonly NhanVienRepository _NhanVienRepository;

        public NhanVienService(IMapper mapper, NhanVienRepository NhanVienRepository)
        {
            _mapper = mapper;
            _NhanVienRepository = NhanVienRepository;
        }

        public async Task<ICollection<NhanVien>> GetAllNhanViensAsync()
        {
            var NhanViens = await _NhanVienRepository.GetNhanViensWithInclude();
            return NhanViens.ToList();
        }

        public async Task<NhanVien> CreateNhanVienAsync(NhanVien model)
        {
            var result = await _NhanVienRepository.CreateNhanVienAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<NhanVien> UpdateNhanVienAsync(NhanVien model)
        {
            var result = await _NhanVienRepository.UpdateNhanVienAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<NhanVien> DeleteNhanVienAsync(string id)
        {
            var result = await GetNhanVienById(id);
            if (result != null)
            {
                result.DeleteDate = DateTime.Now;
                return await UpdateNhanVienAsync(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<NhanVien> GetNhanVienById(string Id)
        {
            return await _NhanVienRepository.GetById(Id);
        }
    }
}
