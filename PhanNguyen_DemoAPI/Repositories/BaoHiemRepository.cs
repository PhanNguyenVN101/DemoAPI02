using Microsoft.EntityFrameworkCore;
using PhanNguyen_DemoAPI.Models;

namespace PhanNguyen_DemoAPI.Repositories
{
    public class BaoHiemRepository : BaseRepository<BaoHiem>
    {
        public async Task<IQueryable<BaoHiem>> GetBaoHiemsWithInclude()
        {
            return _context.Set<BaoHiem>()
                .Where(t => t.DeleteDate == null);
        }

        public async Task<BaoHiem> CreateBaoHiemAsync(BaoHiem model)
        {
            model.DeleteDate = null;
            return await Add(model);
        }

        public async Task<BaoHiem> UpdateBaoHiemAsync(BaoHiem model)
        {
            return await Update(model);
        }
    }
}
