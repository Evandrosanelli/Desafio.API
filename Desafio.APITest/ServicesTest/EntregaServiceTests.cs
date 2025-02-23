using Desafio.API.Entities;
using Desafio.API.Enuns;
using Desafio.API.Interfaces.Repository;
using Desafio.API.Services;
using Moq;

namespace Desafio.APITest.ServicesTest
{
    public class EntregaServiceTests
    {
        private readonly Mock<IEntregaRepository> _entregraRepositoryMock;
        private readonly Mock<IPedidoRepository> _pedidoRepositoryMock;
        private readonly Mock<IDroneRepository> _droneRepositoryMock;
        private readonly EntregaService _entregaService;

        public EntregaServiceTests()
        {
            _entregraRepositoryMock = new Mock<IEntregaRepository>();
            _pedidoRepositoryMock = new Mock<IPedidoRepository>();
            _droneRepositoryMock = new Mock<IDroneRepository>();
            _entregaService = new EntregaService(_droneRepositoryMock.Object, _pedidoRepositoryMock.Object, _entregraRepositoryMock.Object);
        }
        [Fact]
        public async Task SearchDeliveriesInProgress_ShouldReturnDeliveriesInProgress()
        {
            // Arrange
            var entregas = new List<Entrega>(){
                new Entrega { Id = 1, DroneId = 2, PedidoId = 6 },
                new Entrega { Id = 2, DroneId = 7, PedidoId = 9 } };

            _entregraRepositoryMock.Setup(repo => repo.SearchDeliveriesInProgress()).ReturnsAsync(entregas);

            // Act
            var resultado = await _entregaService.SearchDeliveriesInProgress();

            // Assert
            _entregraRepositoryMock.Verify(repo => repo.SearchDeliveriesInProgress(), Times.Once);
            Assert.True(entregas.Count == resultado.Count);
            Assert.Equal(entregas[0], resultado[0]);
            Assert.Equal(entregas[1], resultado[1]);
        }
        [Fact]
        public async Task DataBaseUpdate_ShouldUpdateDataBase()
        {
            // Arrange
            HashSet<Drone> drones = new HashSet<Drone> { new Drone { Id = 1,Latitude=31m,Longitude=32m,StatusDroneId = StatusDroneEnum.Available } };
            HashSet<Pedido> pedidos = new HashSet<Pedido> { new Pedido { Id = 1, Latitude = 31m, Longitude = 32m, StatusPedidoId = StatusPedidoEnum.Delivered } };
            HashSet<Entrega> entregas = new HashSet<Entrega> { new Entrega { Id = 1, DroneId = 12, PedidoId = 44 } };

            _entregraRepositoryMock.Setup(repo => repo.AddRangeAsync(entregas));
            _pedidoRepositoryMock.Setup(repo => repo.UpdateRangeAsync(pedidos));
            _droneRepositoryMock.Setup(repo => repo.UpdateRangeAsync(drones));

            // Act
            await _entregaService.DataBaseUpdate(drones,pedidos,entregas);

            // Assert
            _entregraRepositoryMock.Verify(repo => repo.AddRangeAsync(entregas), Times.Once);
            _droneRepositoryMock.Verify(repo => repo.UpdateRangeAsync(drones), Times.Once);
            _pedidoRepositoryMock.Verify(repo => repo.UpdateRangeAsync(pedidos), Times.Once);
        }
        [Fact]
        public async Task DataBaseUpdate_ShouldNotUpdateDataBase()
        {
            // Arrange
            HashSet<Drone> drones = new HashSet<Drone>();
            HashSet<Pedido> pedidos = new HashSet<Pedido>();
            HashSet<Entrega> entregas = new HashSet<Entrega>();

            _entregraRepositoryMock.Setup(repo => repo.AddRangeAsync(entregas));
            _pedidoRepositoryMock.Setup(repo => repo.UpdateRangeAsync(pedidos));
            _droneRepositoryMock.Setup(repo => repo.UpdateRangeAsync(drones));

            // Act
            await _entregaService.DataBaseUpdate(drones, pedidos, entregas);

            // Assert
            _entregraRepositoryMock.Verify(repo => repo.AddRangeAsync(entregas), Times.Never);
            _droneRepositoryMock.Verify(repo => repo.UpdateRangeAsync(drones), Times.Never);
            _pedidoRepositoryMock.Verify(repo => repo.UpdateRangeAsync(pedidos), Times.Never);
        }
        [Fact]
        public async Task CalculateApproximateDistance_ShouldCalculateDistance()
        {
            // Arrange
            Drone drone = new Drone() { Id = 1,Latitude = -27.85622303527842m, Longitude = -54.18939331694957m, StatusDroneId = StatusDroneEnum.Available}; 
            Pedido pedido = new Pedido() { Id = 1, Latitude = -27.851954427014366m, Longitude = -54.19033745451096m, StatusPedidoId = StatusPedidoEnum.AwaitingDelivery };

            // Act
            var distancia = _entregaService.CalculateApproximateDistance(drone, pedido);

            // Assert
            Assert.Equal(0.486665936931661, distancia);
        }
        [Fact]
        public async Task SearchDroneCloser_ShouldReturnDroneCloser()
        {
            // Arrange
            Drone drone = new Drone { Id = 1, Latitude = 31m, Longitude = 32m, StatusDroneId = StatusDroneEnum.Available };
            HashSet<Drone> drones = new HashSet<Drone> { drone };
            Pedido pedido = new Pedido() { Id = 1, Latitude = -27.851954427014366m, Longitude = -54.19033745451096m, StatusPedidoId = StatusPedidoEnum.AwaitingDelivery };

            // Act
            var resultado = _entregaService.SearchDroneCloser(drones, pedido);

            // Assert
            Assert.Equal(drone.Id,resultado.Id);
        }
        [Fact]
        public async Task AllocateDrones_ShouldReturnListOffEntregas()
        {
            // Arrange
            List<Drone> drones = new List<Drone>() { new Drone { Id = 7, Latitude = -27.85622303527842m, Longitude = -54.18939331694957m, StatusDroneId = StatusDroneEnum.Available } };
            List<Pedido> pedidos = new List<Pedido>() { new Pedido { Id = 2, Latitude = -27.851954427014366m, Longitude = -54.19033745451096m, StatusPedidoId = StatusPedidoEnum.AwaitingDelivery } };
            List<Entrega> entregas = new List<Entrega>() { new Entrega { Id = 0, DroneId = 7, PedidoId = 2 } };
            
            _pedidoRepositoryMock.Setup(repo => repo.FindByStatus(StatusPedidoEnum.AwaitingDelivery)).ReturnsAsync(pedidos);
            _droneRepositoryMock.Setup(repo => repo.FindByStatus(StatusDroneEnum.Available)).ReturnsAsync(drones);

            // Act
            var resultado = await _entregaService.AllocateDrones();

            // Assert
            Assert.Single(resultado);
            Assert.Equal(entregas[0].Id, resultado[0].Id);
            Assert.Equal(entregas[0].DroneId, resultado[0].DroneId);
            Assert.Equal(entregas[0].PedidoId, resultado[0].PedidoId);
        }
    }

}