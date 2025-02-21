using Microsoft.AspNetCore.Mvc;
using Desafio.API.Entities;
using Desafio.API.Interfaces.Service;
using Desafio.API.Enuns;

namespace Desafio.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService ?? throw new ArgumentNullException(nameof(pedidoService));
        }

        [HttpGet]
        public async Task<IActionResult> FindAll() {
            return Ok(await _pedidoService.FindAll());
        }
        [HttpGet("{status}")]
        public async Task<IActionResult> FindByStatus(StatusPedidoEnum status) {
            return Ok(await _pedidoService.FindByStatus(status));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Pedido pedido) {
            if (pedido is null) 
                return BadRequest(pedido);
            return Ok(await _pedidoService.Create(pedido));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(StatusPedidoEnum status, long id) {
            return Ok(await _pedidoService.UpdateStatus(status, id));
        }
    }
}
