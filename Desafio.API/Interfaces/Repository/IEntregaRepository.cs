using Desafio.API.Entities;
using System.Collections.Concurrent;

namespace Desafio.API.Interfaces.Repository
{
    public interface IEntregaRepository
    {
        public Task AddRangeAsync(IEnumerable<Entrega> entrega);
        public Task<List<Entrega>> SearchDeliveriesInProgress();
    }
}
