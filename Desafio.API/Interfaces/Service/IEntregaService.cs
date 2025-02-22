using Desafio.API.Entities;

namespace Desafio.API.Interfaces.Service
{
    public interface IEntregaService
    {
        public Task<List<Entrega>> AllocateDrones();
        public Task<List<Entrega>> SearchDeliveriesInProgress();

    }
}
