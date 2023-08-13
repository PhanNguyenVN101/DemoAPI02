using AutoMapper;
using PhanNguyen_DemoAPI.Models;
using PhanNguyen_DemoAPI.Repositories;

namespace PhanNguyen_DemoAPI.Services
{
    public interface IBaoHiemService
    {
        public Task<ICollection<BaoHiem>> GetAllBaoHiemsAsync();
        public Task<BaoHiem> CreateBaoHiemAsync(BaoHiem model);
        public Task<BaoHiem> UpdateBaoHiemAsync(BaoHiem model);
        public Task<BaoHiem> DeleteBaoHiemAsync(string id);
    }
    public class BaoHiemService : IBaoHiemService
    {
        private readonly IMapper _mapper;
        private readonly BaoHiemRepository _BaoHiemRepository;

        public BaoHiemService(IMapper mapper, BaoHiemRepository BaoHiemRepository)
        {
            _mapper = mapper;
            _BaoHiemRepository = BaoHiemRepository;
        }

        public async Task<ICollection<BaoHiem>> GetAllBaoHiemsAsync()
        {
            var BaoHiems = await _BaoHiemRepository.GetBaoHiemsWithInclude();
            return BaoHiems.ToList();
        }

        public async Task<BaoHiem> CreateBaoHiemAsync(BaoHiem model)
        {
            var result = await _BaoHiemRepository.CreateBaoHiemAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<BaoHiem> UpdateBaoHiemAsync(BaoHiem model)
        {
            var result = await _BaoHiemRepository.UpdateBaoHiemAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<BaoHiem> DeleteBaoHiemAsync(string id)
        {
            var result = await GetBaoHiemById(id);
            if (result != null)
            {
                result.DeleteDate = DateTime.Now;
                return await UpdateBaoHiemAsync(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<BaoHiem> GetBaoHiemById(string Id)
        {
            return await _BaoHiemRepository.GetById(Id);
        }
    }
}
