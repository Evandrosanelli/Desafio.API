using Desafio.API.Entities;
using Desafio.API.Enuns;
using Desafio.API.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        private IDroneService _droneService;
        public DroneController(IDroneService droneService)
        {
            _droneService = droneService ?? throw new ArgumentNullException(nameof(droneService));
        }
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await _droneService.FindAll());
        }
        [HttpGet("{status}")]
        public async Task<IActionResult> FindByStatus(StatusDroneEnum status) 
        {
            return Ok(await _droneService.FindByStatus(status));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Drone drone) 
        {
            return Ok(await _droneService.Create(drone));
        }
        [HttpPut("{id}/status/{status}")]
        public async Task<IActionResult> UpdateStatus(StatusDroneEnum status, long id) 
        {
            return Ok(await _droneService.UpdateStatus(status, id));
        }
        [HttpPut("{id}/coordinates")]
        public async Task<IActionResult> UpdateCoordinates(long id, decimal latitude, decimal longitude) 
        {
            await _droneService.UpdateCoordinates(id, latitude, longitude);
            return Ok();
        }
        [HttpPut("{id}/status-coordinates")]
        public async Task<IActionResult> UpdateStatusAndCoordinates(long id, decimal latitude, decimal longitude, StatusDroneEnum status) 
        {
            return Ok(await _droneService.UpdateStatusAndCoordinates(id, latitude, longitude, status));
        }
    }
}
