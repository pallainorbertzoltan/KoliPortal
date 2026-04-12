using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoliPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KollegiumController : ControllerBase
    {
        private readonly IKollegium _service;
        public KollegiumController(IKollegium service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Kollegium>>> GetAll()
        {
            var list = await _service.GetAll();
            return Ok(list);
        }
    }
}
