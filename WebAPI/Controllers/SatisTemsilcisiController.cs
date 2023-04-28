using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatisTemsilcisiController : ControllerBase
    {
        ISatisTemsilcisiService _satisTemsilcisiService;
        public SatisTemsilcisiController(ISatisTemsilcisiService satisTemsilcisiService)
        {
            _satisTemsilcisiService= satisTemsilcisiService;
        }

        [HttpPost("add")]
        public IActionResult Add(SatisTemsilcisi satisTemsilcisi)
        {
            var result = _satisTemsilcisiService.Add(satisTemsilcisi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(SatisTemsilcisi satisTemsilcisi)
        {
            var result = _satisTemsilcisiService.Delete(satisTemsilcisi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(SatisTemsilcisi satisTemsilcisi)
        {
            var result = _satisTemsilcisiService.Update(satisTemsilcisi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _satisTemsilcisiService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _satisTemsilcisiService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbysatistemsilcisiadi")]
        public IActionResult GetBySatisTemsilcisiAdi(string satisTemsilcisiAdi)
        {
            var result = _satisTemsilcisiService.GetBySatisTemsilcisiAdi(satisTemsilcisiAdi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
