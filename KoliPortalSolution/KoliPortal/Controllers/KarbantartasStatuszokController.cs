using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoliPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KarbantartasStatuszokController : ControllerBase
    {
        private readonly IKarbantartasStatuszok _service;
        public KarbantartasStatuszokController(IKarbantartasStatuszok service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<KarbantartasStatuszok>>> GetAll()
        {
            var list = await _service.GetAll();
            return Ok(list);
        }
    }
}
