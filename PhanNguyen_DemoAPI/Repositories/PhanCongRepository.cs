using Microsoft.EntityFrameworkCore;
using PhanNguyen_DemoAPI.Models;

namespace PhanNguyen_DemoAPI.Repositories
{
    public class PhanCongRepository : BaseRepository<PhanCong>
    {
        public async Task<IQueryable<PhanCong>> GetPhanCongsWithInclude()
        {
            return _context.Set<PhanCong>()
                .Where(t => t.DeleteDate == null);
        }

        public async Task<PhanCong> CreatePhanCongAsync(PhanCong model)
        {
            model.DeleteDate = null;
            return await Add(model);
        }

        public async Task<PhanCong> UpdatePhanCongAsync(PhanCong model)
        {
            return await Update(model);
        }
    }
}
