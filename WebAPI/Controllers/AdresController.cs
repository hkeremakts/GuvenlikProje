using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresController : ControllerBase
    {
        IAdresService _adresService;
        public AdresController(IAdresService adresService)
        {
            _adresService=adresService;
        }

        [HttpPost("add")]
        public IActionResult Add(Adres adres)
        {
            var result = _adresService.Add(adres);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var adres = _adresService.GetById(id);
            var result = _adresService.Delete(adres.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Adres adres)
        {
            var result = _adresService.Update(adres);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _adresService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _adresService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyadresno")]
        public IActionResult GetByAdresNo(string adresNo)
        {
            var result = _adresService.GetByAdresNo(adresNo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
