using Moq;
using Orangotango.Business.Application.Commands.RoomTypes;
using Orangotango.Business.Application.Inputs.RoomTypes;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;
using Orangotango.Core.DomainObjects;
using Orangotango.Tests.Fakes;
using Orangotango.Tests.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Orangotango.Tests.Application.Commands.RoomTypes
{
    public class UpdateRoomTypeCommandTest
    {
        [Fact]
        public async Task UpdateRoomTypeWithTheSameName_Executed_DoesNotUpdate()
        {
            var updateRoomTypeCommand = new UpdateRoomTypeCommand(new UpdateRoomTypeInputModel
            {
                Id = Guid.Parse("26c24541-32e7-4078-9e32-98eba9c8c32c"),
                Name = "Premium"
            });

            var roomTypeRepository = GetRoomTypeRepositoryMock();
            var UpdateRoomTypeCommandHandler = new UpdateRoomTypeCommandHandler(roomTypeRepository.Object, AutoMapperSingleton.Mapper);
            var commandHandlerResult = await UpdateRoomTypeCommandHandler.Handle(updateRoomTypeCommand, new CancellationToken());

            Assert.NotNull(commandHandlerResult);
            Assert.True(commandHandlerResult.IsInvalid);
        }

        [Fact]
        public async Task UpdateEntityWithUniqueName_Executed_UpdatedEntity()
        {
            var updateRoomTypeCommand = new UpdateRoomTypeCommand(new UpdateRoomTypeInputModel
            {
                Id = Guid.Parse("26c24541-32e7-4078-9e32-98eba9c8c32c"),
                Name = "Master"
            });

            var roomTypeRepository = GetRoomTypeRepositoryMock();
            var UpdateRoomTypeCommandHandler = new UpdateRoomTypeCommandHandler(roomTypeRepository.Object, AutoMapperSingleton.Mapper);
            var commandHandlerResult = await UpdateRoomTypeCommandHandler.Handle(updateRoomTypeCommand, new CancellationToken());

            Assert.NotNull(commandHandlerResult);
            Assert.False(commandHandlerResult.IsInvalid);
        }

        [Fact]
        public void UpdateEntityDoesNotExistInDatabase_Executed_ReturnException()
        {
            var updateRoomTypeCommand = new UpdateRoomTypeCommand(new UpdateRoomTypeInputModel
            {
                Id = Guid.Parse("3d399527-a852-4eec-9b3f-c41b00736890"),
                Name = "Master"
            });

            var roomTypeRepository = GetRoomTypeRepositoryMock();
            var UpdateRoomTypeCommandHandler = new UpdateRoomTypeCommandHandler(roomTypeRepository.Object, AutoMapperSingleton.Mapper);

            var domainException = Record.Exception(() => UpdateRoomTypeCommandHandler.Handle
                                                        (updateRoomTypeCommand, new CancellationToken()).Wait());

            Assert.NotNull(domainException);
            Assert.IsType<DomainException>(domainException.InnerException);
        }

        private static Mock<IRoomTypeRepository> GetRoomTypeRepositoryMock()
        {
            var roomTypeMock = new RoomType
            {
                Id = Guid.Parse("26c24541-32e7-4078-9e32-98eba9c8c32c"),
                Name = "Premium"
            };

            var roomTypeRepository = new Mock<IRoomTypeRepository>();
            roomTypeRepository.Setup(respository => respository.HasNameAndHasTheRightId(It.Is<string>(roomType => roomType.Equals(roomTypeMock.Name)), It.IsAny<Guid>()))
                                                               .ReturnsAsync(true);

            roomTypeRepository.Setup(respository => respository.HasNameAndHasTheRightId(It.Is<string>(roomType => !roomType.Equals(roomTypeMock.Name)), It.IsAny<Guid>()))
                                                               .ReturnsAsync(false);

            roomTypeRepository.Setup(respository => respository.GetById(It.Is<Guid>(id => id == roomTypeMock.Id)))
                                                               .Returns(Task.FromResult(roomTypeMock));

            roomTypeRepository.Setup(respository => respository.GetById(It.Is<Guid>(id => id != roomTypeMock.Id)))
                                                               .Returns(Task.FromResult(null as RoomType));

            roomTypeRepository.Setup(respository => respository.Update(It.IsAny<RoomType>()));
            roomTypeRepository.Setup(respository => respository.UnitOfWork).Returns(new UnitOfWorkFake());

            return roomTypeRepository;
        }
    }
}
