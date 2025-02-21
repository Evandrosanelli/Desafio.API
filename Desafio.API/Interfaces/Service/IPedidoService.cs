using Desafio.API.Entities;
using Desafio.API.Enuns;

namespace Desafio.API.Interfaces.Service
{
    public interface IPedidoService
    {
        public Task<List<Pedido>> FindAll();
        public Task<List<Pedido>> FindByStatus(StatusPedidoEnum status);
        public Task<List<Pedido>> Create(Pedido pedido);
        public Task<List<Pedido>> UpdateStatus(StatusPedidoEnum status,long Id);

    }
}
