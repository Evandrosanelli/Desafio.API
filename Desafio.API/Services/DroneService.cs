using Desafio.API.Entities;
using Desafio.API.Enuns;
using Desafio.API.Interfaces.Repository;
using Desafio.API.Interfaces.Service;

namespace Desafio.API.Services
{
    public class DroneService:IDroneService
    {
        private IDroneRepository _droneRepository;
        public DroneService(IDroneRepository droneRepository)
        {
            _droneRepository = droneRepository;
        }
        public Task<List<Drone>> FindAll()
        {
            return _droneRepository.FindAll();
        }
        public Task<List<Drone>> FindByStatus(StatusDroneEnum status)
        {
            return _droneRepository.FindByStatus(status);
        }
        public async Task<List<Drone>> Create(Drone drone)
        {
            await _droneRepository.Create(drone);
            return await _droneRepository.FindAll();
        }
        public async Task<List<Drone>> UpdateStatus(StatusDroneEnum status, long id)
        {
            var drone = await _droneRepository.FindById(id);
            try
            {
                if (drone is null)
                    throw new Exception("Drone não localizado");

                drone.StatusDroneId = status;
                await _droneRepository.Update(drone);
                return await _droneRepository.FindAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task UpdateCoordinates(long id,decimal latitude,decimal longitude)
        {
            var drone = await _droneRepository.FindById(id);
            try
            {
                if (drone is null)
                    throw new Exception("Drone não localizado");

                drone.Latitude = latitude;
                drone.Latitude = longitude;
                
                await _droneRepository.Update(drone);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Drone>> UpdateStatusAndCoordinates(long id, decimal latitude,decimal longitude,StatusDroneEnum status)
        {
            var drone = await _droneRepository.FindById(id);
            try
            {
                if (drone is null)
                    throw new Exception("Drone não localizado");

                drone.StatusDroneId = status;
                drone.Latitude = latitude;
                drone.Latitude = longitude;
                await _droneRepository.Update(drone);

                return await _droneRepository.FindAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
