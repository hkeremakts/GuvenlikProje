using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        IFirmaService _firmaService;
        public FirmaController(IFirmaService firmaService)
        {
            _firmaService = firmaService;
        }

        [HttpPost("add")]
        public IActionResult Add(Firma firma)
        {
            var result = _firmaService.Add(firma);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var firma = _firmaService.GetById(id);
            var result = _firmaService.Delete(firma.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Firma firma)
        {
            var result = _firmaService.Update(firma);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _firmaService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _firmaService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyfirmaadicontains")]
        public IActionResult GetByFirmaAdiContains(string firmaAdi)
        {
            var result = _firmaService.GetByFirmaAdiContains(firmaAdi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getfirmacomponentsbyid")]
        public IActionResult GetFirmaComponentsById(int id)
        {
            var result = _firmaService.GetFirmaComponentsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallfirmacomponents")]
        public IActionResult GetAllFirmaComponents()
        {
            var result = _firmaService.GetAllFirmaComponents();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpGet("getbyadresid")]
        //public IActionResult GetByAdresId(int adresId)
        //{
        //    var result = _firmaService.GetByAdresId(adresId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}
