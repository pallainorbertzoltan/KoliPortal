using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoliPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SzerepkorokController : ControllerBase
    {
        private readonly ISzerepkorok _service;
        public SzerepkorokController(ISzerepkorok service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Szerepkorok>>> GetAll()
        {
            var lista = await _service.GetAll();
            return Ok(lista);
        }
    }
}
