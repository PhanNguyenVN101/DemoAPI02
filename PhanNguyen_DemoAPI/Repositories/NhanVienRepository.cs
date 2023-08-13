using Microsoft.EntityFrameworkCore;
using PhanNguyen_DemoAPI.Models;

namespace PhanNguyen_DemoAPI.Repositories
{
    public class NhanVienRepository : BaseRepository<NhanVien>
    {
        public async Task<IQueryable<NhanVien>> GetNhanViensWithInclude()
        {
            return _context.Set<NhanVien>().Include(i => i.BaoHiems)
                .Where(t => t.DeleteDate == null);
        }

        public async Task<NhanVien> CreateNhanVienAsync(NhanVien model)
        {
            model.DeleteDate = null;
            return await Add(model);
        }

        public async Task<NhanVien> UpdateNhanVienAsync(NhanVien model)
        {
            return await Update(model);
        }
    }
}
