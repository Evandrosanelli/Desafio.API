using Desafio.API.Entities;
using Desafio.API.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Desafio.API.Repositories
{
    public class EntregaRepository : IEntregaRepository
    {
        private readonly PostgreContext _context;
        public EntregaRepository(PostgreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddRangeAsync(IEnumerable<Entrega> entregas)
        {
            await _context.Entrega.AddRangeAsync(entregas);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Entrega>> SearchDeliveriesInProgress()
        {
            var query = from e in _context.Entrega
                        join d in _context.Drone on e.DroneId equals d.Id
                        join p in _context.Pedido on e.DroneId equals p.Id
                        where d.StatusDroneId == Enuns.StatusDroneEnum.Delivering &&
                        p.StatusPedidoId == Enuns.StatusPedidoEnum.DeliveryInProgress
                        select new Entrega { Id = e.Id, DroneId = e.DroneId, PedidoId = e.PedidoId};
            
            return await query.ToListAsync();               
        }
    }
}
