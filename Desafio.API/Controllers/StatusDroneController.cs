using Desafio.API.Entities;
using Desafio.API.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StatusDroneController : ControllerBase
    {
        private IStatusDroneService _statusDroneService;

        public StatusDroneController(IStatusDroneService statusDroneService)
        {
            _statusDroneService = statusDroneService ?? throw new ArgumentNullException(nameof(statusDroneService));
        }
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await _statusDroneService.FindAll());
        }
        [HttpPost]
        public async Task<IActionResult> Create(StatusDrone status)
        {
            if (status is null)
                return BadRequest();

            return Ok(await _statusDroneService.Create(status));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(await _statusDroneService.Delete(id));
        }
    }
}
