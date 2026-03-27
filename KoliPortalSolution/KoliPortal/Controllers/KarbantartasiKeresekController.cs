using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoliPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KarbantartasiKeresekController : ControllerBase
    {
        private readonly IKarbantartasiKeresek _service;
        public KarbantartasiKeresekController(IKarbantartasiKeresek service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<KarbantartasiKeresek>>> GetAll()
        {
            var list = await _service.GetAll();
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult<KarbantartasiKeresek>> Create([FromBody] KarbantartasiKeresek karbantartasiKeresek)
        {
            await _service.Add(karbantartasiKeresek);
            return Ok(karbantartasiKeresek.ID);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] KarbantartasiKeresek karbantartasiKeresek)
        {
            await _service.Update(karbantartasiKeresek);
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
