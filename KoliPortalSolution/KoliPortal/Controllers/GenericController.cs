using KoliPortal.API.INTERFACE;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoliPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : class
    {
        private readonly IGenericKoliPortal<T> _service;

        public GenericController(IGenericKoliPortal<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<T>>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<T>> GetById(int id)
        {
            var entity = await _service.GetById(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<T>> Create([FromBody] T entity)
        {
            var created = await _service.Add(entity);
            return Ok(created);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] T entity)
        {
            await _service.Update(entity);
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
