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
    public class DuAnController : ControllerBase
    {
        private readonly IDuAnService _DuAnService;
        private readonly IMapper _mapper;

        public DuAnController(IDuAnService DuAnService, IMapper mapper)
        {
            _DuAnService = DuAnService;
            _mapper = mapper;
        }

        [HttpGet("DuAns")]
        public async Task<IActionResult> GetDuAns()
        {
            var result = await _DuAnService.GetAllDuAnsAsync();
            return Ok(_mapper.Map<List<DuAnResponse>>(result));
        }

        [HttpPost("DuAn")]
        public async Task<IActionResult> CreateDuAn(DuAnResponse model)
        {
            var result = await _DuAnService.CreateDuAnAsync(_mapper.Map<DuAn>(model));

            return Ok(_mapper.Map<DuAnResponse>(result));
        }

        [HttpPut("edit/{keyId}")]
        public async Task<IActionResult> UpdateDuAn(string keyId, DuAnResponse model)
        {
            var temp = _mapper.Map<DuAn>(model);
            temp.Id = keyId;
            var result = await _DuAnService.UpdateDuAnAsync(temp);
            return Ok(_mapper.Map<DuAnResponse>(result));
        }
        [HttpDelete("delete/{keyId}")]
        public async Task<IActionResult> DeleteDuAn(string keyId)
        {
            var result = await _DuAnService.DeleteDuAnAsync(keyId);
            var returnRes = _mapper.Map<DuAnResponse>(result);

            return Ok(returnRes);
        }
    }
}
