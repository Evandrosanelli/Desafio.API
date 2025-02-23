using Desafio.API.Entities;
using Desafio.API.Enuns;
using Desafio.API.Interfaces.Repository;
using Desafio.API.Interfaces.Service;
using Desafio.API.Services;
using Moq;
using System.Text;

namespace Desafio.APITest.ServicesTest
{
    public class DroneServiceTests
    {
        private readonly Mock<IDroneRepository> _droneRepositoryMock;
        private readonly DroneService _droneService;

        public DroneServiceTests()
        {
            _droneRepositoryMock = new Mock<IDroneRepository>();
            _droneService = new DroneService(_droneRepositoryMock.Object);
        }
        [Fact]
        public async Task FindAll_ShouldReturnAll()
        {
            // Arrange
            var drones = new List<Drone>(){
                new Drone { Id = 1, Latitude = -39.9m, Longitude = -40.8m ,StatusDroneId = API.Enuns.StatusDroneEnum.Available },
                new Drone { Id = 2, Latitude = -34.9m, Longitude = -36.8m ,StatusDroneId = API.Enuns.StatusDroneEnum.Available } };

            _droneRepositoryMock.Setup(repo => repo.FindAll()).ReturnsAsync(drones);

            // Act
            var resultado = await _droneService.FindAll();

            // Assert
            _droneRepositoryMock.Verify(repo => repo.FindAll(), Times.Once);
            Assert.True(drones.Count == resultado.Count);
            Assert.Equal(drones[0], resultado[0]);
            Assert.Equal(drones[1], resultado[1]);
        }
        [Fact]
        public async Task FindByStatus_ShouldReturnByStatus()
        {
            // Arrange
            var status = StatusDroneEnum.Available;
            var drones = new List<Drone>(){
                new Drone { Id = 1, Latitude = -39.9m, Longitude = -40.8m ,StatusDroneId = API.Enuns.StatusDroneEnum.Available },
                new Drone { Id = 2, Latitude = -34.9m, Longitude = -36.8m ,StatusDroneId = API.Enuns.StatusDroneEnum.Unavailable } };

            _droneRepositoryMock.Setup(repo => repo.FindByStatus(status)).ReturnsAsync(drones);

            // Act
            var resultado = await _droneService.FindByStatus(status);

            // Assert
            _droneRepositoryMock.Verify(repo => repo.FindByStatus(status), Times.Once);
            Assert.True(drones.Count == resultado.Count);
            Assert.Equal(drones[0], resultado[0]);
            Assert.Equal(drones[1], resultado[1]);
        }
        [Fact]
        public async Task Create_ShouldAddStatusAndReturnAll()
        {
            // Arrange
            var drone = new Drone { Id = 1, Latitude = -39.9m, Longitude = -40.8m, StatusDroneId = API.Enuns.StatusDroneEnum.Available };
            var drones = new List<Drone>(){new Drone { Id = 1, Latitude = -39.9m, Longitude = -40.8m ,StatusDroneId = StatusDroneEnum.Available }};

            _droneRepositoryMock.Setup(repo => repo.Create(drone)).ReturnsAsync(drone);
            _droneRepositoryMock.Setup(repo => repo.FindAll()).ReturnsAsync(drones);

            // Act
            var resultado = await _droneService.Create(drone);

            // Assert
            _droneRepositoryMock.Verify(repo => repo.Create(drone), Times.Once);
            _droneRepositoryMock.Verify(repo => repo.FindAll(), Times.Once);
            Assert.Single(resultado);
            Assert.Equal(drone.Id, resultado[0].Id);
        }
        [Fact]
        public async Task UpdateStatus_ShouldUpdateStatusAndReturnAll_WhenDroneExists()
        {
            // Arrange
            var drone = new Drone { Id = 1, Latitude = -39.9m, Longitude = -40.8m, StatusDroneId = StatusDroneEnum.Available };
            var drones = new List<Drone>() { new Drone { Id = 1, Latitude = -39.9m, Longitude = -40.8m, StatusDroneId = StatusDroneEnum.Available } };

            _droneRepositoryMock
                .Setup(repo => repo.FindById(drone.Id))
                .ReturnsAsync(drone);

            _droneRepositoryMock
                .Setup(repo => repo.Update(drone))
                .Verifiable();

            _droneRepositoryMock
                .Setup(repo => repo.FindAll())
                .ReturnsAsync(drones);

            // Act
            var resultado = await _droneService.UpdateStatus(StatusDroneEnum.Unavailable,drone.Id);

            // Assert
            _droneRepositoryMock.Verify(repo => repo.FindById(drone.Id), Times.Once);
            _droneRepositoryMock.Verify(repo => repo.Update(drone), Times.Once);
            _droneRepositoryMock.Verify(repo => repo.FindAll(), Times.Once);

            Assert.Equal(drones.Count, resultado.Count);
            Assert.Equal(drones[0].Id, resultado[0].Id);
        }
        [Fact]
        public async Task UpdateStatus_ShouldThrowException_WhenDroneNotFound()
        {
            // Arrange
            var droneId = 999L;

            _droneRepositoryMock
                .Setup(repo => repo.FindById(droneId))
                .ReturnsAsync((Drone)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _droneService.UpdateStatus(StatusDroneEnum.Delivering,droneId));

            Assert.Equal("Drone não localizado", exception.Message);
        }
        [Fact]
        public async Task UpdateCoordinates_ShouldUpdateCoordinatesAndReturnAll_WhenDroneExists()
        {
            // Arrange
            var drone = new Drone { Id = 1, Latitude = -39.9m, Longitude = -40.8m, StatusDroneId = StatusDroneEnum.Available };
            var drones = new List<Drone>() { new Drone { Id = 1, Latitude = -39.9m, Longitude = -40.8m, StatusDroneId = StatusDroneEnum.Available } };

            _droneRepositoryMock
                .Setup(repo => repo.FindById(drone.Id))
                .ReturnsAsync(drone);

            _droneRepositoryMock
                .Setup(repo => repo.Update(drone))
                .Verifiable();

            // Act
            await _droneService.UpdateCoordinates(drone.Id,-31.8m,-38.2m);

            // Assert
            _droneRepositoryMock.Verify(repo => repo.FindById(drone.Id), Times.Once);
            _droneRepositoryMock.Verify(repo => repo.Update(drone), Times.Once);
        }
        [Fact]
        public async Task UpdateCoordinates_ShouldThrowException_WhenDroneNotFound()
        {
            // Arrange
            var droneId = 999L;

            _droneRepositoryMock
                .Setup(repo => repo.FindById(droneId))
                .ReturnsAsync((Drone)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _droneService.UpdateCoordinates(droneId, -31.8m, -38.2m));

            Assert.Equal("Drone não localizado", exception.Message);
        }
        [Fact]
        public async Task UpdateStatusAndCoordinates_ShouldUpdateStatusAndCoordinatesAndReturnAll_WhenDroneExists()
        {
            // Arrange
            var drone = new Drone { Id = 1, Latitude = -39.9m, Longitude = -40.8m, StatusDroneId = StatusDroneEnum.Available };
            var drones = new List<Drone>() { new Drone { Id = 1, Latitude = -39.9m, Longitude = -40.8m, StatusDroneId = StatusDroneEnum.Available } };

            _droneRepositoryMock
                .Setup(repo => repo.FindById(drone.Id))
                .ReturnsAsync(drone);

            _droneRepositoryMock
                .Setup(repo => repo.Update(drone))
                .Verifiable();

            _droneRepositoryMock
                .Setup(repo => repo.FindAll())
                .ReturnsAsync(drones);

            // Act
            await _droneService.UpdateStatusAndCoordinates(drone.Id, -31.8m, -38.2m,StatusDroneEnum.Delivering);

            // Assert
            _droneRepositoryMock.Verify(repo => repo.FindById(drone.Id), Times.Once);
            _droneRepositoryMock.Verify(repo => repo.Update(drone), Times.Once);
            _droneRepositoryMock.Verify(repo => repo.FindAll(), Times.Once);
        }
        [Fact]
        public async Task UpdateStatusAndCoordinates_ShouldThrowException_WhenDroneNotFound()
        {
            // Arrange
            var droneId = 999L;

            _droneRepositoryMock
                .Setup(repo => repo.FindById(droneId))
                .ReturnsAsync((Drone)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(
                () => _droneService.UpdateStatusAndCoordinates(droneId, -31.8m, -38.2m, StatusDroneEnum.Delivering));

            Assert.Equal("Drone não localizado", exception.Message);
        }

    }

}