using Desafio.API.Entities;
using Desafio.API.Enuns;
using Desafio.API.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Desafio.API.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PostgreContext _context;
        public PedidoRepository(PostgreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task<List<Pedido>> FindAll()
        {
            return _context.Pedido.ToListAsync();
        }
        public Task<List<Pedido>> FindByStatus(StatusPedidoEnum status)
        {
            return _context.Pedido.Where(x => x.StatusPedidoId == status).ToListAsync();
        }
        public async Task<Pedido> FindById(long id)
        {
            return await _context.Pedido.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Pedido> Create(Pedido pedido)
        {
            var obj = _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();
            return obj.Entity;
        }
        public async Task Update(Pedido pedido)
        {
            _context.Pedido.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<Pedido> pedidos)
        {
            _context.Pedido.UpdateRange(pedidos);
            await _context.SaveChangesAsync();
        }
    }
}
