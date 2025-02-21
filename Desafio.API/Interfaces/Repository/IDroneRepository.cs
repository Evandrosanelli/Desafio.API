using Desafio.API.Entities;
using Desafio.API.Enuns;

namespace Desafio.API.Interfaces.Repository
{
    public interface IDroneRepository
    {
        public Task<List<Drone>> FindAll();
        public Task<List<Drone>> FindByStatus(StatusDroneEnum status);
        public Task<Drone> FindById(long id);
        public Task<Drone> Create(Drone drone);
        public Task Update(Drone drone);
    }
}
