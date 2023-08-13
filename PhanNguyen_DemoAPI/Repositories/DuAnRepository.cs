using Microsoft.EntityFrameworkCore;
using PhanNguyen_DemoAPI.Models;

namespace PhanNguyen_DemoAPI.Repositories
{
    public class DuAnRepository : BaseRepository<DuAn>
    {
        public async Task<IQueryable<DuAn>> GetDuAnsWithInclude()
        {
            return _context.Set<DuAn>()
                .Where(t => t.DeleteDate == null);
        }

        public async Task<DuAn> CreateDuAnAsync(DuAn model)
        {
            model.DeleteDate = null;
            return await Add(model);
        }

        public async Task<DuAn> UpdateDuAnAsync(DuAn model)
        {
            return await Update(model);
        }
    }
}
