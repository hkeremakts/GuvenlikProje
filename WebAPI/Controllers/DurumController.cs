using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DurumController : ControllerBase
    {
        IDurumService _durumService;
        public DurumController(IDurumService durumService)
        {
            _durumService=durumService;
        }

        [HttpPost("add")]
        public IActionResult Add(Durum durum)
        {
            var result = _durumService.Add(durum);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Durum durum)
        {
            var result = _durumService.Delete(durum);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Durum durum)
        {
            var result = _durumService.Update(durum);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _durumService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _durumService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbydurumadi")]
        public IActionResult GetByDurumAdi(string durumAdi)
        {
            var result = _durumService.GetByDurumAdi(durumAdi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
