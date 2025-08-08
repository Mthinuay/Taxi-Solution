using Microsoft.AspNetCore.Mvc;
using Adingisa.Services;
using Adingisa.Dtos; // Fixed namespace (Dto**s**, not DTOs)
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adingisa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiLocationController : ControllerBase
    {
        private readonly ITaxiLocationService _service;

        public TaxiLocationController(ITaxiLocationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxiLocationReadDto>>> GetAll()
        {
            try
            {
                var locations = await _service.GetAllAsync();
                return Ok(locations);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaxiLocationReadDto>> GetById(int id)
        {
            try
            {
                var location = await _service.GetByIdAsync(id);
                return location == null ? NotFound() : Ok(location);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<TaxiLocationReadDto>> Create(TaxiLocationCreateDto dto)
        {
            try
            {
                var created = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.TaxiLocationId }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaxiLocationUpdateDto dto)
        {
            try
            {
                bool updated = await _service.UpdateAsync(id, dto);
                return updated ? NoContent() : NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool deleted = await _service.DeleteAsync(id);
                return deleted ? NoContent() : NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
