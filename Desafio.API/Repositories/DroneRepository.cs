using Desafio.API.Entities;
using Desafio.API.Enuns;
using Desafio.API.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Desafio.API.Repositories
{
    public class DroneRepository : IDroneRepository
    {
        private readonly PostgreContext _context;
        public DroneRepository(PostgreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task<List<Drone>> FindAll()
        {
            return _context.Drone.ToListAsync();
        }
        public Task<List<Drone>> FindByStatus(StatusDroneEnum status)
        {
            return _context.Drone.Where(x => x.StatusDroneId == status).ToListAsync();
        }
        public async Task<Drone> FindById(long id)
        {
            return await _context.Drone.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Drone> Create(Drone drone)
        {
            var obj = _context.Drone.Add(drone);
            await _context.SaveChangesAsync();
            return obj.Entity;
        }
        public async Task Update(Drone drone)
        {
            _context.Drone.Update(drone);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRangeAsync(IEnumerable<Drone> drones)
        {
            _context.Drone.UpdateRange(drones);
            await _context.SaveChangesAsync();
        }
    }
}
