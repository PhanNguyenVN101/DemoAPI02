using AutoMapper;
using PhanNguyen_DemoAPI.Models;
using PhanNguyen_DemoAPI.Repositories;

namespace PhanNguyen_DemoAPI.Services
{
    public interface IDuAnService
    {
        public Task<ICollection<DuAn>> GetAllDuAnsAsync();
        public Task<DuAn> CreateDuAnAsync(DuAn model);
        public Task<DuAn> UpdateDuAnAsync(DuAn model);
        public Task<DuAn> DeleteDuAnAsync(string id);
    }
    public class DuAnService : IDuAnService
    {
        private readonly IMapper _mapper;
        private readonly DuAnRepository _DuAnRepository;

        public DuAnService(IMapper mapper, DuAnRepository DuAnRepository)
        {
            _mapper = mapper;
            _DuAnRepository = DuAnRepository;
        }

        public async Task<ICollection<DuAn>> GetAllDuAnsAsync()
        {
            var DuAns = await _DuAnRepository.GetDuAnsWithInclude();
            return DuAns.ToList();
        }

        public async Task<DuAn> CreateDuAnAsync(DuAn model)
        {
            var result = await _DuAnRepository.CreateDuAnAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<DuAn> UpdateDuAnAsync(DuAn model)
        {
            var result = await _DuAnRepository.UpdateDuAnAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<DuAn> DeleteDuAnAsync(string id)
        {
            var result = await GetDuAnById(id);
            if (result != null)
            {
                result.DeleteDate = DateTime.Now;
                return await UpdateDuAnAsync(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<DuAn> GetDuAnById(string Id)
        {
            return await _DuAnRepository.GetById(Id);
        }
    }
}
