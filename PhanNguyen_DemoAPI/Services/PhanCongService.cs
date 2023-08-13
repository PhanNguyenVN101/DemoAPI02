using AutoMapper;
using PhanNguyen_DemoAPI.Models;
using PhanNguyen_DemoAPI.Repositories;

namespace PhanNguyen_DemoAPI.Services
{
    public interface IPhanCongService
    {
        public Task<ICollection<PhanCong>> GetAllPhanCongsAsync();
        public Task<PhanCong> CreatePhanCongAsync(PhanCong model);
        public Task<PhanCong> UpdatePhanCongAsync(PhanCong model);
        public Task<PhanCong> DeletePhanCongAsync(string nhanvienId, string duanId);
    }
    public class PhanCongService : IPhanCongService
    {
        private readonly IMapper _mapper;
        private readonly PhanCongRepository _PhanCongRepository;

        public PhanCongService(IMapper mapper, PhanCongRepository PhanCongRepository)
        {
            _mapper = mapper;
            _PhanCongRepository = PhanCongRepository;
        }

        public async Task<ICollection<PhanCong>> GetAllPhanCongsAsync()
        {
            var PhanCongs = await _PhanCongRepository.GetPhanCongsWithInclude();
            return PhanCongs.ToList();
        }

        public async Task<PhanCong> CreatePhanCongAsync(PhanCong model)
        {
            var result = await _PhanCongRepository.CreatePhanCongAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<PhanCong> UpdatePhanCongAsync(PhanCong model)
        {
            var result = await _PhanCongRepository.UpdatePhanCongAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<PhanCong> DeletePhanCongAsync(string nhanvienId, string duanId)
        {
            var result = await GetPhanCongById(nhanvienId,duanId);
            if (result != null)
            {
                result.DeleteDate = DateTime.Now;
                return await UpdatePhanCongAsync(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<PhanCong> GetPhanCongById(string nhanvienId, string duanId)
        {
            return await _PhanCongRepository.GetById(nhanvienId,duanId);
        }
    }
}
