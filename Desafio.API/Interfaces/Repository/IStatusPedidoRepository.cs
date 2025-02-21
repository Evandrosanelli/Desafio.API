using Desafio.API.Entities;

namespace Desafio.API.Interfaces.Repository
{
    public interface IStatusPedidoRepository
    {
        public Task<List<StatusPedido>> FindAll();
        public Task<StatusPedido> FindById(long id);
        public Task<StatusPedido> Create(StatusPedido status);
        public Task<bool> Delete(StatusPedido status);
    }
}
