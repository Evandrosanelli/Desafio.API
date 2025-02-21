using Desafio.API.Entities;
using Desafio.API.Enuns;
using Microsoft.EntityFrameworkCore;

namespace Desafio.API.Interfaces.Repository
{
    public interface IPedidoRepository
    {
        public Task<List<Pedido>> FindAll();
        public Task<List<Pedido>> FindByStatus(StatusPedidoEnum status);
        public Task<Pedido> FindById(long id);
        public Task<Pedido> Create(Pedido pedido);
        public Task Update(Pedido pedido);
    }
}
