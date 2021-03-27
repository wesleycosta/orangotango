using AutoMapper;
using MediatR;
using Orangotango.Business.Application.Inputs.RoomTypes;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;
using Orangotango.Business.ViewModels.RoomTypes;
using Orangotango.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace Orangotango.Business.Application.Commands.RoomTypes
{
    public class RegisterRoomTypeCommandHandler : CommandHandler, IRequestHandler<RegisterRoomTypeCommand, CommandHandlerResult>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IMapper _mapper;

        public RegisterRoomTypeCommandHandler(IRoomTypeRepository roomTypeRepository,
                                              IMapper mapper)
        {
            _roomTypeRepository = roomTypeRepository;
            _mapper = mapper;
        }

        public async Task<CommandHandlerResult> Handle(RegisterRoomTypeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return Response(request);

            if (!await BusinessIsValid(request.InputModel))
                return Response();

            return Response(await AddRoomTypeAndSaveData(request));
        }

        private async Task<bool> BusinessIsValid(RegisterRoomTypeInputModel inputModel)
        {
            if (await _roomTypeRepository.HasName(inputModel.Name))
            {
                NotifyError($"Já existe uma categoria cadastrada com o nome {inputModel.Name}");
                return false;
            }

            return true;
        }

        private async Task<CommandHandlerResult> AddRoomTypeAndSaveData(RegisterRoomTypeCommand request)
        {
            var roomType = AddRoomType(request);
            var viewModel = _mapper.Map<RoomTypeViewModel>(roomType);
            return await SaveData(_roomTypeRepository.UnitOfWork, viewModel);
        }

        private RoomType AddRoomType(RegisterRoomTypeCommand request)
        {
            var roomType = new RoomType
            {
                Id = request.AggregateId,
                Name = request.InputModel.Name
            };

            _roomTypeRepository.Add(roomType);
            return roomType;
        }
    }
}
