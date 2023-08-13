using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhanNguyen_DemoAPI.Models;
using PhanNguyen_DemoAPI.Models.ResponseModels;
using PhanNguyen_DemoAPI.Repositories;
using PhanNguyen_DemoAPI.ResponseModels;
using PhanNguyen_DemoAPI.Services;

namespace PhanNguyen_DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhanCongController : ControllerBase
    {
        private readonly IPhanCongService _PhanCongService;
        private readonly IMapper _mapper;

        public PhanCongController(IPhanCongService PhanCongService, IMapper mapper)
        {
            _PhanCongService = PhanCongService;
            _mapper = mapper;
        }

        [HttpGet("PhanCongs")]
        public async Task<IActionResult> GetPhanCongs()
        {
            var result = await _PhanCongService.GetAllPhanCongsAsync();
            return Ok(_mapper.Map<List<PhanCongResponse>>(result));
        }

        [HttpPost("PhanCong")]
        public async Task<IActionResult> CreatePhanCong(PhanCongResponse model)
        {
            var result = await _PhanCongService.CreatePhanCongAsync(_mapper.Map<PhanCong>(model));

            return Ok(_mapper.Map<PhanCongResponse>(result));
        }

        [HttpPut("edit/{nhanvienId}&{duanId}")]
        public async Task<IActionResult> UpdatePhanCong(string nhanvienId, string duanId, PhanCongResponse model)
        {
            var temp = _mapper.Map<PhanCong>(model);
            temp.NhanVienId = nhanvienId;
            temp.DuAnId = duanId;
            var result = await _PhanCongService.UpdatePhanCongAsync(temp);
            return Ok(_mapper.Map<PhanCongResponse>(result));
        }
        [HttpDelete("delete/{nhanvienId}&{duanId}")]
        public async Task<IActionResult> DeletePhanCong(string nhanvienId, string duanId)
        {
            var result = await _PhanCongService.DeletePhanCongAsync(nhanvienId,duanId);
            var returnRes = _mapper.Map<PhanCongResponse>(result);

            return Ok(returnRes);
        }
    }
}
