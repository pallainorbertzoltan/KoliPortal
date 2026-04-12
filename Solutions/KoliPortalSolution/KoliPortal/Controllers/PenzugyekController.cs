using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoliPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenzugyekController : ControllerBase
    {
        private readonly IPenzugyek _service;
        public PenzugyekController(IPenzugyek service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Penzugyek>>> GetAll()
        {
            var lista = await _service.GetAll();
            return Ok(lista);
        }
        [HttpPost]
        public async Task<ActionResult<Penzugyek>> Create([FromBody] Penzugyek penzugyek)
        {
            await _service.Add(penzugyek);
            return Ok(penzugyek.ID);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Penzugyek penzugyek)
        {
            await _service.Update(penzugyek);
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
