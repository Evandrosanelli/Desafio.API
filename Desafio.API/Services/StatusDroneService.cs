using Desafio.API.Entities;
using Desafio.API.Interfaces.Repository;
using Desafio.API.Interfaces.Service;
using Desafio.API.Repositories;

namespace Desafio.API.Services
{
    public class StatusDroneService : IStatusDroneService
    {
        private IStatusDroneRepository _statusDroneRepository;
        public StatusDroneService(IStatusDroneRepository statusDroneRepository)
        {
            _statusDroneRepository = statusDroneRepository ?? throw new ArgumentNullException(nameof(statusDroneRepository));
        }
        public Task<List<StatusDrone>> FindAll()
        {
            return _statusDroneRepository.FindAll();
        }
        public async Task<List<StatusDrone>> Create(StatusDrone status) {
            await _statusDroneRepository.Create(status);
            return await _statusDroneRepository.FindAll();
        }
        public async Task<List<StatusDrone>> Delete(long id)
        {
            var status = await _statusDroneRepository.FindById(id);
            try
            {
                if (status is null)
                    throw new Exception("Status não localizado");

                await _statusDroneRepository.Delete(status);
                return await _statusDroneRepository.FindAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
