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
    public class PhongBanController : ControllerBase
    {
        private readonly IPhongBanService _PhongBanService;
        private readonly IMapper _mapper;

        public PhongBanController(IPhongBanService PhongBanService, IMapper mapper)
        {
            _PhongBanService = PhongBanService;
            _mapper = mapper;
        }

        [HttpGet("PhongBans")]
        public async Task<IActionResult> GetPhongBans()
        {
            var result = await _PhongBanService.GetAllPhongBansAsync();
            return Ok(_mapper.Map<List<PhongBan>>(result));
        }

        [HttpPost("PhongBan")]
        public async Task<IActionResult> CreatePhongBan(PhongBanResponse model)
        {
            var result = await _PhongBanService.CreatePhongBanAsync(_mapper.Map<PhongBan>(model));

            return Ok(_mapper.Map<PhongBanResponse>(result));
        }

        [HttpPut("edit/{keyId}")]
        public async Task<IActionResult> UpdatePhongBan(string keyId, PhongBanResponse model)
        {
            var temp = _mapper.Map<PhongBan>(model);
            temp.Id = keyId;
            var result = await _PhongBanService.UpdatePhongBanAsync(temp);
            return Ok(_mapper.Map<PhongBanResponse>(result));
        }
        [HttpDelete("delete/{keyId}")]
        public async Task<IActionResult> DeletePhongBan(string keyId)
        {
            var result = await _PhongBanService.DeletePhongBanAsync(keyId);
            var returnRes = _mapper.Map<PhongBanResponse>(result);

            return Ok(returnRes);
        }
    }
}
