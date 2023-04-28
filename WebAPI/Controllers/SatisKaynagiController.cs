using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatisKaynagiController : ControllerBase
    {
        ISatisKaynagiService _satisKaynagiService;
        public SatisKaynagiController(ISatisKaynagiService satisKaynagiService)
        {
            _satisKaynagiService= satisKaynagiService;
        }

        [HttpPost("add")]
        public IActionResult Add(SatisKaynagi satisKaynagi)
        {
            var result = _satisKaynagiService.Add(satisKaynagi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(SatisKaynagi satisKaynagi)
        {
            var result = _satisKaynagiService.Delete(satisKaynagi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(SatisKaynagi satisKaynagi)
        {
            var result = _satisKaynagiService.Update(satisKaynagi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _satisKaynagiService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _satisKaynagiService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbysatiskaynagiadi")]
        public IActionResult GetBySatisKaynagiAdi(string satisKaynagiAdi)
        {
            var result = _satisKaynagiService.GetBySatisKaynagiAdi(satisKaynagiAdi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
