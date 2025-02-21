using Desafio.API.Entities;
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
        
    }
}
