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
    public class BaoHiemController : ControllerBase
    {
        private readonly IBaoHiemService _BaoHiemService;
        private readonly IMapper _mapper;

        public BaoHiemController(IBaoHiemService BaoHiemService, IMapper mapper)
        {
            _BaoHiemService = BaoHiemService;
            _mapper = mapper;
        }

        [HttpGet("BaoHiems")]
        public async Task<IActionResult> GetBaoHiems()
        {
            var result = await _BaoHiemService.GetAllBaoHiemsAsync();
            return Ok(_mapper.Map<List<BaoHiemResponse>>(result));
        }

        [HttpPost("BaoHiem")]
        public async Task<IActionResult> CreateBaoHiem(BaoHiemResponse model)
        {
            var result = await _BaoHiemService.CreateBaoHiemAsync(_mapper.Map<BaoHiem>(model));

            return Ok(_mapper.Map<BaoHiemResponse>(result));
        }

        [HttpPut("edit/{keyId}")]
        public async Task<IActionResult> UpdateBaoHiem(string keyId, BaoHiemResponse model)
        {
            var temp = _mapper.Map<BaoHiem>(model);
            temp.Id = keyId;
            var result = await _BaoHiemService.UpdateBaoHiemAsync(temp);
            return Ok(_mapper.Map<BaoHiemResponse>(result));
        }
        [HttpDelete("delete/{keyId}")]
        public async Task<IActionResult> DeleteBaoHiem(string keyId)
        {
            var result = await _BaoHiemService.DeleteBaoHiemAsync(keyId);
            var returnRes = _mapper.Map<BaoHiemResponse>(result);

            return Ok(returnRes);
        }
    }
}
