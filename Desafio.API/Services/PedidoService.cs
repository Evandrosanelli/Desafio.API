using Desafio.API.Entities;
using Desafio.API.Enuns;
using Desafio.API.Interfaces.Repository;
using Desafio.API.Interfaces.Service;
using Microsoft.EntityFrameworkCore;

namespace Desafio.API.Services
{
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository _pedidoRepository;
        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public Task<List<Pedido>> FindAll()
        {
            return _pedidoRepository.FindAll();
        }
        public Task<List<Pedido>> FindByStatus(StatusPedidoEnum status)
        {
            return _pedidoRepository.FindByStatus(status);
        }
        public async Task<List<Pedido>> Create(Pedido pedido)
        {
            await _pedidoRepository.Create(pedido);
            return await _pedidoRepository.FindAll();
        }
        public async Task<List<Pedido>> UpdateStatus(StatusPedidoEnum status, long id)
        {
            var pedido = await _pedidoRepository.FindById(id);
            try
            {
                if (pedido is null)
                    throw new Exception("Pedido não localizado");

                pedido.StatusPedidoId = status;

                await _pedidoRepository.Update(pedido);
                return await _pedidoRepository.FindAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
