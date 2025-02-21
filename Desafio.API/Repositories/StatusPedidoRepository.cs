using Desafio.API.Entities;
using Desafio.API.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Desafio.API.Repositories
{
    public class StatusPedidoRepository : IStatusPedidoRepository
    {
        private readonly PostgreContext _context;
        public StatusPedidoRepository(PostgreContext context)
        {
            _context = context;
        }
        public async Task<List<StatusPedido>> FindAll()
        {
            return await _context.StatusPedido.ToListAsync();
        }
        public async Task<StatusPedido> FindById(long id)
        {
            return await _context.StatusPedido.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<StatusPedido> Create(StatusPedido status)
        {
            var obj = _context.StatusPedido.Add(status);
            await _context.SaveChangesAsync();
            return obj.Entity;
        }
        public async Task<bool> Delete(StatusPedido status)
        {
            try
            {
                _context.StatusPedido.Remove(status);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
