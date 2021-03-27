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
    public class UpdateRoomTypeCommandHandler : CommandHandler, IRequestHandler<UpdateRoomTypeCommand, CommandHandlerResult>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IMapper _mapper;

        public UpdateRoomTypeCommandHandler(IRoomTypeRepository roomTypeRepository,
                                            IMapper mapper)
        {
            _roomTypeRepository = roomTypeRepository;
            _mapper = mapper;
        }

        public async Task<CommandHandlerResult> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return Response(request);

            if (!await BusinessIsValid(request.InputModel))
                return Response();

            return Response(await AddRoomTypeAndSaveData(request));
        }

        private async Task<bool> BusinessIsValid(UpdateRoomTypeInputModel inputModel)
        {
            if (await _roomTypeRepository.HasNameAndHasTheRightId(inputModel.Name, inputModel.Id))
            {
                NotifyError($"Já existe uma categoria cadastrada com o nome {inputModel.Name}");
                return false;
            }

            return true;
        }

        private async Task<CommandHandlerResult> AddRoomTypeAndSaveData(UpdateRoomTypeCommand request)
        {
            var roomType = await UpdateRoomType(request);
            var viewModel = _mapper.Map<RoomTypeViewModel>(roomType);

            return await SaveData(unitOfWork: _roomTypeRepository.UnitOfWork, responseCommand: viewModel);
        }

        private async Task<RoomType> UpdateRoomType(UpdateRoomTypeCommand request)
        {
            var roomType = await LoadEntityAndMapperFields(request);
            _roomTypeRepository.Update(roomType);

            return roomType;
        }

        private async Task<RoomType> LoadEntityAndMapperFields(UpdateRoomTypeCommand request)
        {
            var roomType = await _roomTypeRepository.GetById(request.AggregateId);
            if (roomType == null)
                EntryNotFoundException();

            roomType.Name = request.InputModel.Name;
            return roomType;
        }
    }
}
