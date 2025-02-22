using Desafio.API.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EntregaController : ControllerBase
    {
        private IEntregaService _entregaService;
        public EntregaController(IEntregaService entregaService)
        {
            _entregaService = entregaService ?? throw new ArgumentNullException(nameof(entregaService));
        }
        [HttpPost]
        public async Task<IActionResult> AllocateDrones()
        {
            return Ok(await _entregaService.AllocateDrones());
        }
        [HttpGet]
        public async Task<IActionResult> SearchDeliveriesInProgress()
        {
            return Ok(await _entregaService.SearchDeliveriesInProgress());
        }
    }
}
