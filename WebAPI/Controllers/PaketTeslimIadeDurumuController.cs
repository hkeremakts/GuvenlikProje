using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaketTeslimIadeDurumuController : ControllerBase
    {
        IPaketTeslimIadeDurumuService _paketTeslimIadeDurumuService;
        public PaketTeslimIadeDurumuController(IPaketTeslimIadeDurumuService paketTeslimIadeDurumuService)
        {
            _paketTeslimIadeDurumuService= paketTeslimIadeDurumuService; 
        }

        [HttpPost("add")]
        public IActionResult Add(PaketTeslimIadeDurumu paketTeslimIadeDurumu)
        {
            var result = _paketTeslimIadeDurumuService.Add(paketTeslimIadeDurumu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PaketTeslimIadeDurumu paketTeslimIadeDurumu)
        {
            var result = _paketTeslimIadeDurumuService.Delete(paketTeslimIadeDurumu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PaketTeslimIadeDurumu paketTeslimIadeDurumu)
        {
            var result = _paketTeslimIadeDurumuService.Update(paketTeslimIadeDurumu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _paketTeslimIadeDurumuService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _paketTeslimIadeDurumuService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbypaketteslimiadedurumuadi")]
        public IActionResult GetByPaketTeslimIadeDurumuAdi(string paketTeslimIadeDurumuAdi)
        {
            var result = _paketTeslimIadeDurumuService.GetByPaketTeslimIadeDurumuAdi(paketTeslimIadeDurumuAdi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
