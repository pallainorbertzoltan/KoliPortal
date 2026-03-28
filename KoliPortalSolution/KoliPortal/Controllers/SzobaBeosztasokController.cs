using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoliPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SzobaBeosztasokController : ControllerBase
    {
        private readonly ISzobaBeosztasok _service;
        public SzobaBeosztasokController(ISzobaBeosztasok service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SzobaBeosztasok>>> GetAll()
        {
            var lista = await _service.GetAll();
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<SzobaBeosztasok>> Create([FromBody] SzobaBeosztasok szobaBeosztasok)
        {
            await _service.Add(szobaBeosztasok);
            return Ok(szobaBeosztasok.ID);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] SzobaBeosztasok szobaBeosztasok)
        {
            await _service.Update(szobaBeosztasok);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
