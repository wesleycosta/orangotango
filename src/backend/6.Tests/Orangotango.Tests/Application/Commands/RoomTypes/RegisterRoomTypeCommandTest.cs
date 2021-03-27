using Moq;
using Orangotango.Business.Application.Commands.RoomTypes;
using Orangotango.Business.Application.Inputs.RoomTypes;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;
using Orangotango.Tests.Infrastructure;
using Orangotango.Tests.Infrastructure.Fakes;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Orangotango.Tests.Application.Commands.RoomTypes
{
    public class RegisterRoomTypeCommandTest
    {
        [Fact]
        public async Task RegisterRoomType_Executed_ReturnFalse()
        {
            // Arrange
            var registerRoomTypeCommand = new RegisterRoomTypeCommand(new RegisterRoomTypeInputModel
            {
                Name = "Premium"
            });

            var roomTypeRepository = GetRoomTypeRepositoryMock();
            var registerRoomTypeCommandHandler = new RegisterRoomTypeCommandHandler(roomTypeRepository.Object, AutoMapperSingleton.Mapper);
            
            // Act
            var commandHandlerResult = await registerRoomTypeCommandHandler.Handle(registerRoomTypeCommand, new CancellationToken());

            // Assert
            Assert.NotNull(commandHandlerResult);
            Assert.True(commandHandlerResult.IsInvalid);
        }

        [Fact]
        public async Task RegisterRoomType_Executed_ReturnTrue()
        {
            // Arrange
            var registerRoomTypeCommand = new RegisterRoomTypeCommand(new RegisterRoomTypeInputModel
            {
                Name = "Master"
            });

            var roomTypeRepository = GetRoomTypeRepositoryMock();
            var registerRoomTypeCommandHandler = new RegisterRoomTypeCommandHandler(roomTypeRepository.Object, AutoMapperSingleton.Mapper);

            // Act
            var commandHandlerResult = await registerRoomTypeCommandHandler.Handle(registerRoomTypeCommand, new CancellationToken());

            // Assert
            Assert.NotNull(commandHandlerResult);
            Assert.False(commandHandlerResult.IsInvalid);
        }

        private static Mock<IRoomTypeRepository> GetRoomTypeRepositoryMock()
        {
            var roomTypeMock = new RoomType
            {
                Id = Guid.NewGuid(),
                Name = "Premium"
            };

            var roomTypeRepository = new Mock<IRoomTypeRepository>();
            roomTypeRepository.Setup(respository => respository.HasName(It.Is<string>(roomType => roomType.Equals(roomTypeMock.Name))))
                                                               .ReturnsAsync(true);

            roomTypeRepository.Setup(respository => respository.HasName(It.Is<string>(roomType => !roomType.Equals(roomTypeMock.Name))))
                                                               .ReturnsAsync(false);

            roomTypeRepository.Setup(respository => respository.UnitOfWork).Returns(new UnitOfWorkFake());

            return roomTypeRepository;
        }
    }
}
