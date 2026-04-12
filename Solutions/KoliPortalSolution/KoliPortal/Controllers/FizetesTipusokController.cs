using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoliPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizetesTipusokController : ControllerBase
    {
        private readonly IFizetesTipusok _service;
        public FizetesTipusokController(IFizetesTipusok service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<FizetesTipusok>>> GetAll()
        {
            var lista = await _service.GetAll();
            return Ok(lista);
        }
    }
}
