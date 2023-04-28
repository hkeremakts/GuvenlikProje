using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaYetkiliController : ControllerBase
    {
        IFirmaYetkiliService _firmaYetkiliService;
        public FirmaYetkiliController(IFirmaYetkiliService firmaYetkiliService)
        {
            _firmaYetkiliService=firmaYetkiliService;
        }

        [HttpPost("add")]
        public IActionResult Add(FirmaYetkili firmaYetkili)
        {
            var result = _firmaYetkiliService.Add(firmaYetkili);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var firmaYetkili = _firmaYetkiliService.GetById(id);
            var result = _firmaYetkiliService.Delete(firmaYetkili.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(FirmaYetkili firmaYetkili)
        {
            var result = _firmaYetkiliService.Update(firmaYetkili);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _firmaYetkiliService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _firmaYetkiliService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyfirmayetkiliadi")]
        public IActionResult GetByFirmaYetkiliAdi(string firmaYetkiliAdi)
        {
            var result = _firmaYetkiliService.GetByFirmaYetkiliAdi(firmaYetkiliAdi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
