using AutoMapper;
using PhanNguyen_DemoAPI.Models;
using PhanNguyen_DemoAPI.Repositories;

namespace PhanNguyen_DemoAPI.Services
{
    public interface IPhongBanService
    {
        public Task<ICollection<PhongBan>> GetAllPhongBansAsync();
        public Task<PhongBan> CreatePhongBanAsync(PhongBan model);
        public Task<PhongBan> UpdatePhongBanAsync(PhongBan model);
        public Task<PhongBan> DeletePhongBanAsync(string id);
    }
    public class PhongBanService : IPhongBanService
    {
        private readonly IMapper _mapper;
        private readonly PhongBanRepository _PhongBanRepository;

        public PhongBanService(IMapper mapper, PhongBanRepository PhongBanRepository)
        {
            _mapper = mapper;
            _PhongBanRepository = PhongBanRepository;
        }

        public async Task<ICollection<PhongBan>> GetAllPhongBansAsync()
        {
            var PhongBans = await _PhongBanRepository.GetPhongBansWithInclude();
            return PhongBans.ToList();
        }

        public async Task<PhongBan> CreatePhongBanAsync(PhongBan model)
        {
            var result = await _PhongBanRepository.CreatePhongBanAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<PhongBan> UpdatePhongBanAsync(PhongBan model)
        {
            var result = await _PhongBanRepository.UpdatePhongBanAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<PhongBan> DeletePhongBanAsync(string id)
        {
            var result = await GetPhongBanById(id);
            if (result != null)
            {
                result.DeleteDate = DateTime.Now;
                return await UpdatePhongBanAsync(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<PhongBan> GetPhongBanById(string Id)
        {
            return await _PhongBanRepository.GetById(Id);
        }
    }
}
