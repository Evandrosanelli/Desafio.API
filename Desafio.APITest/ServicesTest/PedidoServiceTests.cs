using Desafio.API.Entities;
using Desafio.API.Enuns;
using Desafio.API.Interfaces.Repository;
using Desafio.API.Interfaces.Service;
using Desafio.API.Services;
using Moq;
using System.Text;

namespace Desafio.APITest.ServicesTest
{
    public class PedidoServiceTests
    {
        private readonly Mock<IPedidoRepository> _pedidoRepositoryMock;
        private readonly PedidoService _pedidoService;

        public PedidoServiceTests()
        {
            _pedidoRepositoryMock = new Mock<IPedidoRepository>();
            _pedidoService = new PedidoService(_pedidoRepositoryMock.Object);
        }
        [Fact]
        public async Task FindAll_ShouldReturnAll()
        {
            // Arrange
            var pedidos = new List<Pedido>(){
                new Pedido { Id = 1, Latitude = -39.9m, Longitude = -40.8m ,StatusPedidoId = StatusPedidoEnum.Delivered },
                new Pedido { Id = 2, Latitude = -34.9m, Longitude = -36.8m ,StatusPedidoId = StatusPedidoEnum.AwaitingDelivery } };

            _pedidoRepositoryMock.Setup(repo => repo.FindAll()).ReturnsAsync(pedidos);

            // Act
            var resultado = await _pedidoService.FindAll();

            // Assert
            _pedidoRepositoryMock.Verify(repo => repo.FindAll(), Times.Once);
            Assert.True(pedidos.Count == resultado.Count);
            Assert.Equal(pedidos[0], resultado[0]);
            Assert.Equal(pedidos[1], resultado[1]);
        }
        [Fact]
        public async Task FindByStatus_ShouldReturnByStatus()
        {
            // Arrange
            var status = StatusPedidoEnum.AwaitingDelivery;
            var pedidos = new List<Pedido>(){
                new Pedido { Id = 1, Latitude = -39.9m, Longitude = -40.8m ,StatusPedidoId = StatusPedidoEnum.AwaitingDelivery },
                new Pedido { Id = 2, Latitude = -34.9m, Longitude = -36.8m ,StatusPedidoId = StatusPedidoEnum.Delivered } };

            _pedidoRepositoryMock.Setup(repo => repo.FindByStatus(status)).ReturnsAsync(pedidos);

            // Act
            var resultado = await _pedidoService.FindByStatus(status);

            // Assert
            _pedidoRepositoryMock.Verify(repo => repo.FindByStatus(status), Times.Once);
            Assert.True(pedidos.Count == resultado.Count);
            Assert.Equal(pedidos[0], resultado[0]);
            Assert.Equal(pedidos[1], resultado[1]);
        }
        [Fact]
        public async Task Create_ShouldAddPedidoAndReturnAll()
        {
            // Arrange
            var pedido = new Pedido { Id = 1, Latitude = -39.9m, Longitude = -40.8m, StatusPedidoId = StatusPedidoEnum.AwaitingDelivery };
            var pedidos = new List<Pedido>(){new Pedido { Id = 1, Latitude = -39.9m, Longitude = -40.8m ,StatusPedidoId = StatusPedidoEnum.AwaitingDelivery }};

            _pedidoRepositoryMock.Setup(repo => repo.Create(pedido)).ReturnsAsync(pedido);
            _pedidoRepositoryMock.Setup(repo => repo.FindAll()).ReturnsAsync(pedidos);

            // Act
            var resultado = await _pedidoService.Create(pedido);

            // Assert
            _pedidoRepositoryMock.Verify(repo => repo.Create(pedido), Times.Once);
            _pedidoRepositoryMock.Verify(repo => repo.FindAll(), Times.Once);
            Assert.Single(resultado);
            Assert.Equal(pedido.Id, resultado[0].Id);
        }
        [Fact]
        public async Task UpdateStatus_ShouldUpdateStatusAndReturnAll_WhenPedidoExists()
        {
            // Arrange
            var pedido = new Pedido { Id = 1, Latitude = -39.9m, Longitude = -40.8m, StatusPedidoId = StatusPedidoEnum.AwaitingDelivery };
            var pedidos = new List<Pedido>() { new Pedido { Id = 1, Latitude = -39.9m, Longitude = -40.8m, StatusPedidoId = StatusPedidoEnum.AwaitingDelivery } };

            _pedidoRepositoryMock
                .Setup(repo => repo.FindById(pedido.Id))
                .ReturnsAsync(pedido);

            _pedidoRepositoryMock
                .Setup(repo => repo.Update(pedido))
                .Verifiable();

            _pedidoRepositoryMock
                .Setup(repo => repo.FindAll())
                .ReturnsAsync(pedidos);

            // Act
            var resultado = await _pedidoService.UpdateStatus(StatusPedidoEnum.Delivered,pedido.Id);

            // Assert
            _pedidoRepositoryMock.Verify(repo => repo.FindById(pedido.Id), Times.Once);
            _pedidoRepositoryMock.Verify(repo => repo.Update(pedido), Times.Once);
            _pedidoRepositoryMock.Verify(repo => repo.FindAll(), Times.Once);

            Assert.Equal(pedidos.Count, resultado.Count);
            Assert.Equal(pedidos[0].Id, resultado[0].Id);
        }
        [Fact]
        public async Task UpdateStatus_ShouldThrowException_WhenPedidoNotFound()
        {
            // Arrange
            var pedidoId = 999L;

            _pedidoRepositoryMock
                .Setup(repo => repo.FindById(pedidoId))
                .ReturnsAsync((Pedido)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _pedidoService.UpdateStatus(StatusPedidoEnum.Cancelled,pedidoId));

            Assert.Equal("Pedido não localizado", exception.Message);
        }
    }

}