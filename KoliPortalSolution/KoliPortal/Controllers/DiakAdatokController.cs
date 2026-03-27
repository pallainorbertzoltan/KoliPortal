using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoliPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiakAdatokController : ControllerBase
    {
        private readonly IDiakAdatok _service;
        public DiakAdatokController(IDiakAdatok service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<DiakAdatok>>> GetAll()
        {
            var lista = await _service.GetAll();
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<DiakAdatok>> Create([FromBody] DiakAdatok diakAdatok)
        {
            await _service.Add(diakAdatok);
            return Ok(diakAdatok.UserID);
        }

        [HttpPut]
        public async Task<ActionResult> Updat([FromBody] DiakAdatok diakAdatok)
        {
            await _service.Update(diakAdatok);
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
