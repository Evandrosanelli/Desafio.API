using Desafio.API.Entities;
using Desafio.API.Interfaces.Repository;
using Desafio.API.Interfaces.Service;

namespace Desafio.API.Services
{
    public class StatusPedidoService : IStatusPedidoService
    {
        private IStatusPedidoRepository _statusPedidoRepository;
        public StatusPedidoService(IStatusPedidoRepository statusPedidoRepository)
        {
            _statusPedidoRepository = statusPedidoRepository ?? throw new ArgumentNullException(nameof(statusPedidoRepository));
        }
        public Task<List<StatusPedido>> FindAll()
        {
            return _statusPedidoRepository.FindAll();
        }
        public async Task<List<StatusPedido>> Create(StatusPedido status) {
            await _statusPedidoRepository.Create(status);
            return await _statusPedidoRepository.FindAll();
        }
        public async Task<List<StatusPedido>> Delete(long id)
        {
            var status = await _statusPedidoRepository.FindById(id);
            try
            {
                if (status is null)
                    throw new Exception("Status não localizado");

                await _statusPedidoRepository.Delete(status);
                return await _statusPedidoRepository.FindAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
