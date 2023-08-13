using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhanNguyen_DemoAPI.Models;
using PhanNguyen_DemoAPI.Repositories;
using PhanNguyen_DemoAPI.ResponseModels;
using PhanNguyen_DemoAPI.Services;

namespace PhanNguyen_DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _NhanVienService;
        private readonly IMapper _mapper;

        public NhanVienController(INhanVienService NhanVienService, IMapper mapper)
        {
            _NhanVienService = NhanVienService;
            _mapper = mapper;
        }

        [HttpGet("NhanViens")]
        public async Task<IActionResult> GetNhanViens()
        {
            var result = await _NhanVienService.GetAllNhanViensAsync();
            return Ok(_mapper.Map<List<NhanVien>>(result));
        }

        [HttpPost("NhanVien")]
        public async Task<IActionResult> CreateNhanVien(NhanVienResponse model)
        {
            var result = await _NhanVienService.CreateNhanVienAsync(_mapper.Map<NhanVien>(model));

            return Ok(_mapper.Map<NhanVienResponse>(result));
        }

        [HttpPut("edit/{keyId}")]
        public async Task<IActionResult> UpdateNhanVien(string keyId, NhanVienResponse model)
        {
            var temp = _mapper.Map<NhanVien>(model);
            temp.Id = keyId;
            var result = await _NhanVienService.UpdateNhanVienAsync(temp);
            return Ok(_mapper.Map<NhanVienResponse>(result));
        }
        [HttpDelete("delete/{keyId}")]
        public async Task<IActionResult> DeleteNhanVien(string keyId)
        {
            var result = await _NhanVienService.DeleteNhanVienAsync(keyId);
            var returnRes = _mapper.Map<NhanVienResponse>(result);

            return Ok(returnRes);
        }
    }
}
