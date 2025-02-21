using Desafio.API.Entities;

namespace Desafio.API.Interfaces.Service
{
    public interface IStatusPedidoService
    {
        public Task<List<StatusPedido>> FindAll();
        public Task<List<StatusPedido>> Create(StatusPedido status);
        public Task<List<StatusPedido>> Delete(long id);
    }
}
