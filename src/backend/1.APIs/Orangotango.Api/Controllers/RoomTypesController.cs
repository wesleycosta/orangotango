using Microsoft.AspNetCore.Mvc;
using Orangotango.Api.Infrastructure.Controllers;
using Orangotango.Business.Application.Commands.RoomTypes;
using Orangotango.Business.Application.Inputs.RoomTypes;
using Orangotango.Core.Mediator;
using Orangotango.Core.Notifications;
using System.Threading.Tasks;

namespace Orangotango.Api.Controllers
{
    [Route("api/room-types")]
    public class RoomTypesController : MainController
    {
        private readonly IMediatorHandler _mediator;

        public RoomTypesController(INotifier notifier,
                                   IMediatorHandler mediatorHandler) : base(notifier)
        {
            _mediator = mediatorHandler;
        }


        [HttpPost]
        public async Task<IActionResult> Insert(RegisterRoomTypeInputModel input)
        {
            var command = new RegisterRoomTypeCommand(input);
            return CustomResponse(await _mediator.SendCommand(command));
        }
    }
}
