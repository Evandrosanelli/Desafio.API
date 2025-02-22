using Desafio.API.Entities;
using Desafio.API.Enuns;

namespace Desafio.API.Repositories.Seeds
{
    public static class StatusSeeds
    {
        public static List<StatusDrone> GetSeedsStatusDrone()
        {
            var seeds = new List<StatusDrone>()
            {
                new StatusDrone
                {
                    Id = (int)StatusDroneEnum.Available,
                    Descricao = StatusDroneEnum.Available.ToString()
                },
                new StatusDrone
                {
                    Id = (int)StatusDroneEnum.Unavailable,
                    Descricao = StatusDroneEnum.Unavailable.ToString()
                },
                new StatusDrone
                {
                    Id = (int)StatusDroneEnum.Delivering,
                    Descricao = StatusDroneEnum.Delivering.ToString()
                },
            };
            return seeds;
        }
        public static List<StatusPedido> GetSeedsStatusPedido()
        {
            var seeds = new List<StatusPedido>()
            {
                new StatusPedido
                {
                    Id = (int)StatusPedidoEnum.AwaitingDelivery,
                    Descricao = StatusPedidoEnum.AwaitingDelivery.ToString()
                },
                new StatusPedido
                {
                    Id = (int)StatusPedidoEnum.DeliveryInProgress,
                    Descricao = StatusPedidoEnum.DeliveryInProgress.ToString()
                },
                new StatusPedido
                {
                    Id = (int)StatusPedidoEnum.Delivered,
                    Descricao = StatusPedidoEnum.Delivered.ToString()
                },
                new StatusPedido
                {
                    Id = (int)StatusPedidoEnum.Cancelled,
                    Descricao = StatusPedidoEnum.Cancelled.ToString()
                }
            };
            return seeds;
        }
       
    }
}
