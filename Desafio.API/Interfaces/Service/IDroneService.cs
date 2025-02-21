using Desafio.API.Entities;
using Desafio.API.Enuns;

namespace Desafio.API.Interfaces.Service
{
    public interface IDroneService
    {
        public Task<List<Drone>> FindAll();
        public Task<List<Drone>> FindByStatus(StatusDroneEnum status);
        public Task<List<Drone>> Create(Drone drone);
        public Task<List<Drone>> UpdateCoordinates(decimal latitude,decimal longitude,long id);
        public Task<List<Drone>> UpdateStatus(StatusDroneEnum staus,long id);

    }
}
