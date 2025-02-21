using Desafio.API.Entities;
using Desafio.API.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Desafio.API.Repositories
{
    public class StatusDroneRepository : IStatusDroneRepository
    {
        private readonly PostgreContext _context;
        public StatusDroneRepository(PostgreContext context)
        {
            _context = context;
        }
        public async Task<List<StatusDrone>> FindAll()
        {
            return await _context.StatusDrone.ToListAsync();
        }
        public async Task<StatusDrone> FindById(long id)
        {
            return await _context.StatusDrone.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<StatusDrone> Create(StatusDrone status)
        {
            _context.StatusDrone.Add(status);
            await _context.SaveChangesAsync();
            return new StatusDrone();
        }
        public async Task<bool> Delete(StatusDrone status)
        {
            try
            {
                _context.StatusDrone.Remove(status);
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
