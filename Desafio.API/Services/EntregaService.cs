using Desafio.API.Entities;
using Desafio.API.Enuns;
using Desafio.API.Interfaces.Repository;
using Desafio.API.Interfaces.Service;
using System.Diagnostics;

namespace Desafio.API.Services
{
    public class EntregaService : IEntregaService
    {
        private IDroneRepository _droneRepository;
        private IPedidoRepository _pedidoRepository;
        private IEntregaRepository _entregaRepository;

        public EntregaService(IDroneRepository droneRepository, IPedidoRepository pedidoRepository, IEntregaRepository entregaRepository)
        {
            _droneRepository = droneRepository ?? throw new ArgumentNullException(nameof(droneRepository));
            _pedidoRepository = pedidoRepository ?? throw new ArgumentNullException(nameof(pedidoRepository));
            _entregaRepository = entregaRepository ?? throw new ArgumentNullException(nameof(entregaRepository));
        }
        public async Task<List<Entrega>> AllocateDrones()
        {
            //Busca os drones e pedidos disponiveis para ser processados
            var drones = await _droneRepository.FindByStatus(StatusDroneEnum.Available);
            var pedidos = await _pedidoRepository.FindByStatus(StatusPedidoEnum.AwaitingDelivery);

            //Criando as estruturas de dados necessarias - usando HashSet pois a ordenação não é necessaria e porporciona maior performance
            var entregas = new HashSet<Entrega>(); 
            var dronesDisponiveis = new HashSet<Drone>(drones);
            var dronesAtualizar = new HashSet<Drone>();
            var pedidosAtualizar = new HashSet<Pedido>();

            //Percorre os pedidos
            foreach (var pedido in pedidos)
            {
                //Verifica se ha drones disponiveis
                if (!dronesDisponiveis.Any()) break;

                //Busca o Drone mais proximo das coordenadas do pedido
                var drone = SearchDroneCloser(dronesDisponiveis, pedido);

                //Remove o drone da lista de disponiveis para que ele não seja alocado em dois pedidos diferentes
                dronesDisponiveis.Remove(drone);
                
                //Cria um novo objeto de entrega que ira relacionar o drone e o pedido
                var entrega = new Entrega
                {
                    DroneId = drone.Id,
                    PedidoId = pedido.Id
                };

                //Altera o status do drone no objeto e o adiciona a uma lista para depois atualizar o banco de dados
                drone.StatusDroneId = StatusDroneEnum.Delivering;
                dronesAtualizar.Add(drone);

                //Altera o status do pedido no objeto e o adiciona a uma lista para depois atualizar o banco de dados
                pedido.StatusPedidoId = StatusPedidoEnum.DeliveryInProgress;
                pedidosAtualizar.Add(pedido);

                //Adiciona a uma lista para depois atualizar o banco de dados
                entregas.Add(entrega);
            }

            //Faz a chamada para os repositorios para realizar os update/insert
            await DataBaseUpdate(dronesAtualizar, pedidosAtualizar, entregas);

            
            return entregas.ToList();
        }
        private Drone SearchDroneCloser(HashSet<Drone> drones, Pedido pedido)
        {
            //Estrutura de dados que armazena os dados junto de uma prioridade,e permite obter o elemento com a menor ou maior prioridade
            var heap = new PriorityQueue<Drone, double>();
            
            foreach (var drone in drones)
            {
                double distancia = CalculateApproximateDistance(drone, pedido);
                //Adiciona o elemento junto com sua prioridade (distancia) a estrutura
                heap.Enqueue(drone, distancia);
            }
            //Retorna o elemento com a maior prioridade (no caso a menor distancia)
            return heap.Dequeue();
        }
        private static double CalculateApproximateDistance(Drone drone, Pedido pedido)
        {
            //Calculo simplificado para obter a distancia entre as coordenadas, este calculo possui menor
            //precisao em grandes distancias e proximo aos polos porem para o proposito da aplicação acredito ser viavel
            
            //Calcula a diferença em graus
            double dx = (double)(pedido.Longitude - drone.Longitude);
            double dy = (double)(pedido.Latitude - drone.Latitude);

            // Aproximação: 1 grau ≈ 111,32 km
            return Math.Sqrt(dx * dx + dy * dy) * 111.32;
        }
        private async Task DataBaseUpdate(HashSet<Drone> drones, HashSet<Pedido> pedidos, HashSet<Entrega> entregas)
        {
            //Atualiza os status dos drones e pedidos de uma unica vez e tambem inclui as entregas no banco de dados
            if (drones.Any())
            {
                await _droneRepository.UpdateRangeAsync(drones);
            }
            if (pedidos.Any())
            {
                await _pedidoRepository.UpdateRangeAsync(pedidos);
            }
            if (entregas.Any())
            {
                await _entregaRepository.AddRangeAsync(entregas);
            }
        }
        public Task<List<Entrega>> SearchDeliveriesInProgress()
        {
            return _entregaRepository.SearchDeliveriesInProgress();
        }
    }
}
