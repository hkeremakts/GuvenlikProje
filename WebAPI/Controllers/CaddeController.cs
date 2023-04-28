using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaddeController : ControllerBase
    {
        ICaddeService _caddeService;
        public CaddeController(ICaddeService caddeService)
        {
            _caddeService=caddeService;
        }

        [HttpPost("add")]
        public IActionResult Add(Cadde cadde)
        {
            var result = _caddeService.Add(cadde);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Cadde cadde)
        {
            var result = _caddeService.Delete(cadde);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Cadde cadde)
        {
            var result = _caddeService.Update(cadde);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _caddeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _caddeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycaddeadi")]
        public IActionResult GetByCaddeAdi(string caddeAdi)
        {
            var result = _caddeService.GetByCaddeAdi(caddeAdi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
