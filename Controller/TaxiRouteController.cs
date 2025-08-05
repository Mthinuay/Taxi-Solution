// Controllers/TaxiRouteController.cs
using Microsoft.AspNetCore.Mvc;
using Adingisa.Dtos;
using Adingisa.Services.Interfaces;

namespace Adingisa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxiRouteController : ControllerBase
    {
        private readonly ITaxiRouteService _service;

        public TaxiRouteController(ITaxiRouteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var routes = await _service.GetAllAsync();
            return Ok(routes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var route = await _service.GetByIdAsync(id);
            if (route == null)
                return NotFound();

            return Ok(route);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaxiRouteCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.TaxiRouteId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaxiRouteCreateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
