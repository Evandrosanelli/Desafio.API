using Desafio.API.Entities;
using Desafio.API.Interfaces.Repository;
using Desafio.API.Services;
using Moq;

namespace Desafio.APITest.ServicesTest
{
    public class StatusPedidoServiceTests
    {
        private readonly Mock<IStatusPedidoRepository> _statusPedidoRepositoryMock;
        private readonly StatusPedidoService _statusPedidoService;

        public StatusPedidoServiceTests()
        {
            _statusPedidoRepositoryMock = new Mock<IStatusPedidoRepository>();
            _statusPedidoService = new StatusPedidoService(_statusPedidoRepositoryMock.Object);
        }
        [Fact]
        public async Task FindAll_ShouldReturnAll()
        {
            // Arrange
            var listaStatus = new List<StatusPedido>(){
                new StatusPedido { Id = 1, Descricao = "Novo" }, 
                new StatusPedido { Id = 2, Descricao = "Novo2" } };

            _statusPedidoRepositoryMock.Setup(repo => repo.FindAll()).ReturnsAsync(listaStatus);

            // Act
            var resultado = await _statusPedidoService.FindAll();

            // Assert
            _statusPedidoRepositoryMock.Verify(repo => repo.FindAll(), Times.Once);
            Assert.True(listaStatus.Count == resultado.Count);
            Assert.Equal(listaStatus[0], resultado[0]);
            Assert.Equal(listaStatus[1], resultado[1]);
        }
        [Fact]
        public async Task Create_ShouldAddStatusAndReturnAll()
        {
            // Arrange
            var novoStatus = new StatusPedido { Id = 1, Descricao = "Novo" };
            var listaStatus = new List<StatusPedido> { novoStatus };

            _statusPedidoRepositoryMock.Setup(repo => repo.Create(novoStatus)).ReturnsAsync(novoStatus);
            _statusPedidoRepositoryMock.Setup(repo => repo.FindAll()).ReturnsAsync(listaStatus);

            // Act
            var resultado = await _statusPedidoService.Create(novoStatus);

            // Assert
            _statusPedidoRepositoryMock.Verify(repo => repo.Create(novoStatus), Times.Once);
            _statusPedidoRepositoryMock.Verify(repo => repo.FindAll(), Times.Once);
            Assert.Single(resultado);
            Assert.Equal(novoStatus.Descricao, resultado[0].Descricao);
        }
        [Fact]
        public async Task Delete_ShouldDeleteAndReturnAll_WhenStatusExists()
        {
            // Arrange
            var statusId = 1L;
            var status = new StatusPedido { Id = statusId, Descricao = "Pendente" };
            var lista = new List<StatusPedido> { status };

            _statusPedidoRepositoryMock
                .Setup(repo => repo.FindById(statusId))
                .ReturnsAsync(status);

            _statusPedidoRepositoryMock
                .Setup(repo => repo.Delete(status))
                .ReturnsAsync(true);

            _statusPedidoRepositoryMock
                .Setup(repo => repo.FindAll())
                .ReturnsAsync(lista);

            // Act
            var resultado = await _statusPedidoService.Delete(statusId);

            // Assert
            _statusPedidoRepositoryMock.Verify(repo => repo.FindById(statusId), Times.Once);
            _statusPedidoRepositoryMock.Verify(repo => repo.Delete(status), Times.Once);
            _statusPedidoRepositoryMock.Verify(repo => repo.FindAll(), Times.Once);

            Assert.Equal(lista.Count, resultado.Count);
            Assert.Equal(lista[0].Id, resultado[0].Id);
        }
        [Fact]
        public async Task Delete_ShouldThrowException_WhenStatusNotFound()
        {
            // Arrange
            var statusId = 999L;

            _statusPedidoRepositoryMock
                .Setup(repo => repo.FindById(statusId))
                .ReturnsAsync((StatusPedido)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _statusPedidoService.Delete(statusId));

            Assert.Equal("Status não localizado", exception.Message);
        }
    }

}