using Desafio.API.Entities;
using Desafio.API.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StatusPedidoController : ControllerBase
    {
        private IStatusPedidoService _statusPedidoService;

        public StatusPedidoController(IStatusPedidoService statusPedidoService)
        {
            _statusPedidoService = statusPedidoService ?? throw new ArgumentNullException(nameof(statusPedidoService));
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await _statusPedidoService.FindAll());
        }
        [HttpPost]
        public async Task<IActionResult> Create(StatusPedido status)
        {
            if(status is null) 
                return BadRequest();

            return Ok(await _statusPedidoService.Create(status));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(await _statusPedidoService.Delete(id));
        }
    }
}
