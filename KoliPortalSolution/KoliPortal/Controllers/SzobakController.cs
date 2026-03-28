using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoliPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SzobakController : ControllerBase
    {
        private readonly ISzobak _service;
        public SzobakController(ISzobak service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Szobak>>> GetAll()
        {
            var lista = await _service.GetAll();
            return Ok(lista);
        }
    }
}
