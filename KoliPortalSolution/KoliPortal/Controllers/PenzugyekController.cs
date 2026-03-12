using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoliPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenzugyekController : GenericController<Penzugyek>
    {
        public PenzugyekController(IGenericKoliPortal<Penzugyek> service) : base(service)
        {
            
        }
    }
}
