using Desafio.API.Entities;
using Desafio.API.Enuns;

namespace Desafio.API.Interfaces.Service
{
    public interface IDroneService
    {
        public Task<List<Drone>> FindAll();
        public Task<List<Drone>> FindByStatus(StatusDroneEnum status);
        public Task<List<Drone>> Create(Drone drone);
        public Task<List<Drone>> UpdateStatus(StatusDroneEnum status, long id);
        public Task UpdateCoordinates(long id, decimal latitude, decimal longitude);
        public Task<List<Drone>> UpdateStatusAndCoordinates(long id, decimal latitude, decimal longitude, StatusDroneEnum status);
    }
}
