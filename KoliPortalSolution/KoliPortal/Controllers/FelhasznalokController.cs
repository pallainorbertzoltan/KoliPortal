using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoliPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FelhasznalokController : ControllerBase
    {
        private readonly IFelhasznalok _service;

        public FelhasznalokController(IFelhasznalok service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Felhasznalok>>> GetAll()
        {
            var lista = await _service.GetAll();
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<Felhasznalok>> Create([FromBody] Felhasznalok felhasznalok)
        {
            await _service.Add(felhasznalok);
            return Ok(felhasznalok.ID);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Felhasznalok felhasznalok)
        {
            await _service.Update(felhasznalok);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
