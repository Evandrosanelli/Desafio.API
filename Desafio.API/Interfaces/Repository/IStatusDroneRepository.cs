using Desafio.API.Entities;

namespace Desafio.API.Interfaces.Repository
{
    public interface IStatusDroneRepository
    {
        public Task<List<StatusDrone>> FindAll();
        public Task<StatusDrone> Create(StatusDrone status);
        public Task<bool> Delete(StatusDrone status);
        public Task<StatusDrone> FindById(long id);
    }
}
