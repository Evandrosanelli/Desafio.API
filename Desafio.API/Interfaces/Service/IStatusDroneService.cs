using Desafio.API.Entities;

namespace Desafio.API.Interfaces.Service
{
    public interface IStatusDroneService
    {
        public Task<List<StatusDrone>> FindAll();
        public Task<List<StatusDrone>> Create(StatusDrone status);
        public Task<List<StatusDrone>> Delete(long id);
    }
}
