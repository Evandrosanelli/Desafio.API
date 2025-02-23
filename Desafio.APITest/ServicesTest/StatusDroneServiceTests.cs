using Desafio.API.Entities;
using Desafio.API.Interfaces.Repository;
using Desafio.API.Services;
using Moq;

namespace Desafio.APITest.ServicesTest
{
    public class StatusDroneServiceTests
    {
        private readonly Mock<IStatusDroneRepository> _statusDroneRepositoryMock;
        private readonly StatusDroneService _statusDroneService;

        public StatusDroneServiceTests()
        {
            _statusDroneRepositoryMock = new Mock<IStatusDroneRepository>();
            _statusDroneService = new StatusDroneService(_statusDroneRepositoryMock.Object);
        }
        [Fact]
        public async Task FindAll_ShouldReturnAll()
        {
            // Arrange
            var listaStatus = new List<StatusDrone>(){
                new StatusDrone { Id = 1, Descricao = "Novo" }, 
                new StatusDrone { Id = 2, Descricao = "Novo2" } };

            _statusDroneRepositoryMock.Setup(repo => repo.FindAll()).ReturnsAsync(listaStatus);

            // Act
            var resultado = await _statusDroneService.FindAll();

            // Assert
            _statusDroneRepositoryMock.Verify(repo => repo.FindAll(), Times.Once);
            Assert.True(listaStatus.Count == resultado.Count);
            Assert.Equal(listaStatus[0], resultado[0]);
            Assert.Equal(listaStatus[1], resultado[1]);
        }
        [Fact]
        public async Task Create_ShouldAddStatusAndReturnAll()
        {
            // Arrange
            var novoStatus = new StatusDrone { Id = 1, Descricao = "Novo" };
            var listaStatus = new List<StatusDrone> { novoStatus };

            _statusDroneRepositoryMock.Setup(repo => repo.Create(novoStatus)).ReturnsAsync(novoStatus);
            _statusDroneRepositoryMock.Setup(repo => repo.FindAll()).ReturnsAsync(listaStatus);

            // Act
            var resultado = await _statusDroneService.Create(novoStatus);

            // Assert
            _statusDroneRepositoryMock.Verify(repo => repo.Create(novoStatus), Times.Once);
            _statusDroneRepositoryMock.Verify(repo => repo.FindAll(), Times.Once);
            Assert.Single(resultado);
            Assert.Equal(novoStatus.Descricao, resultado[0].Descricao);
        }
        [Fact]
        public async Task Delete_ShouldDeleteAndReturnAll_WhenStatusExists()
        {
            // Arrange
            var statusId = 1L;
            var status = new StatusDrone { Id = statusId, Descricao = "Pendente" };
            var lista = new List<StatusDrone> { status };

            _statusDroneRepositoryMock
                .Setup(repo => repo.FindById(statusId))
                .ReturnsAsync(status);

            _statusDroneRepositoryMock
                .Setup(repo => repo.Delete(status))
                .ReturnsAsync(true);

            _statusDroneRepositoryMock
                .Setup(repo => repo.FindAll())
                .ReturnsAsync(lista);

            // Act
            var resultado = await _statusDroneService.Delete(statusId);

            // Assert
            _statusDroneRepositoryMock.Verify(repo => repo.FindById(statusId), Times.Once);
            _statusDroneRepositoryMock.Verify(repo => repo.Delete(status), Times.Once);
            _statusDroneRepositoryMock.Verify(repo => repo.FindAll(), Times.Once);

            Assert.Equal(lista.Count, resultado.Count);
            Assert.Equal(lista[0].Id, resultado[0].Id);
        }
        [Fact]
        public async Task Delete_ShouldThrowException_WhenStatusNotFound()
        {
            // Arrange
            var statusId = 999L;

            _statusDroneRepositoryMock
                .Setup(repo => repo.FindById(statusId))
                .ReturnsAsync((StatusDrone)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _statusDroneService.Delete(statusId));

            Assert.Equal("Status não localizado", exception.Message);
        }
    }

}