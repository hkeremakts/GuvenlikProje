using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarkliFirmaController : ControllerBase
    {
        IFarkliFirmaService _farkliFirmaService;
        public FarkliFirmaController(IFarkliFirmaService farkliFirmaService)
        {
            _farkliFirmaService= farkliFirmaService;
        }
        [HttpPost("add")]
        public IActionResult Add(FarkliFirma farkliFirma)
        {
            var result = _farkliFirmaService.Add(farkliFirma);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(FarkliFirma farkliFirma)
        {
            var result = _farkliFirmaService.Delete(farkliFirma);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(FarkliFirma farkliFirma)
        {
            var result = _farkliFirmaService.Update(farkliFirma);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _farkliFirmaService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _farkliFirmaService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyfarklifirmaadi")]
        public IActionResult GetByFarkliFirmaAdi(string farkliFirmaAdi)
        {
            var result = _farkliFirmaService.GetByFarkliFirmaAdi(farkliFirmaAdi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
