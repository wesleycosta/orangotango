using Microsoft.AspNetCore.Mvc;
using Orangotango.Api.Infrastructure.Controllers;
using Orangotango.Business.Application.Commands.RoomTypes;
using Orangotango.Business.Application.Inputs.RoomTypes;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Core.Mediator;
using Orangotango.Core.Notifications;
using System.Threading.Tasks;

namespace Orangotango.Api.Controllers
{
    [Route("api/room-types")]
    public class RoomTypesController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypesController(INotifier notifier,
                                   IMediatorHandler mediatorHandler,
                                   IRoomTypeRepository roomTypeRepository) : base(notifier)
        {
            _mediator = mediatorHandler;
            _roomTypeRepository = roomTypeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] RegisterRoomTypeInputModel input)
        {
            var command = new RegisterRoomTypeCommand(input);
            return CustomResponse(await _mediator.SendCommand(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRoomTypeInputModel input)
        {
            var command = new UpdateRoomTypeCommand(input);
            return CustomResponse(await _mediator.SendCommand(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse(await _roomTypeRepository.GetAll());
        }
    }
}
