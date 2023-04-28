using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SokakController : ControllerBase
    {
        ISokakService _sokakService;
        public SokakController(ISokakService sokakService)
        {
            _sokakService = sokakService;
        }

        [HttpPost("add")]
        public IActionResult Add(Sokak sokak)
        {
            var result = _sokakService.Add(sokak);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Sokak sokak)
        {
            var result = _sokakService.Delete(sokak);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Sokak sokak)
        {
            var result = _sokakService.Update(sokak);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _sokakService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _sokakService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbysokakadi")]
        public IActionResult GetBySokakAdi(string sokakAdi)
        {
            var result = _sokakService.GetBySokakAdi(sokakAdi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
