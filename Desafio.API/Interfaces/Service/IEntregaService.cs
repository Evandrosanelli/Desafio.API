using Desafio.API.Entities;

namespace Desafio.API.Interfaces.Service
{
    public interface IEntregaService
    {
        public Task<List<Entrega>> FindAll();
        public Task<List<Entrega>> Create(Entrega entrega);

    }
}
