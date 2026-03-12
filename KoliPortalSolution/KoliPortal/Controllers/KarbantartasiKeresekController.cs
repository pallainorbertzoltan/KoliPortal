using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoliPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KarbantartasiKeresekController : GenericController<KarbantartasiKeresek>
    {
        public KarbantartasiKeresekController(IGenericKoliPortal<KarbantartasiKeresek> service) : base(service)
        {
            
        }
    }
}
