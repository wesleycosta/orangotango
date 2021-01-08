using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Orangotango.Business.Hubs;
using Orangotango.Business.Intefaces.Queries;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Core.Notifications;
using Orangotango.WebApiShared.Controllers;
using System;
using System.Threading.Tasks;

namespace Orangotango.Api.Controllers
{
    [Route("api/secret")]
    public class SecretController : MainControllerWithBearer
    {
        private readonly IUserQueries _userQueries;
        private readonly IHubContext<NotificationHub> _hub;
        private readonly IUserRepository _userRepository;

        public SecretController(INotifier notifier,
                                IUserQueries userQueries,
                                IHubContext<NotificationHub> hub,
                                IUserRepository userRepository) : base(notifier)
        {
            _userQueries = userQueries;
            _hub = hub;
            _userRepository = userRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string id)
        {
            return CustomResponse(await _userRepository.GetById(new Guid(id)));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Insert()
        {
            try
            {
                _userRepository.Add(new Business.Models.User
                {
                    NickName = "Wesley",
                    FristName = "Wesley",
                    LastName = "Costa",
                    Active = true,
                    Email = new Business.Models.DomainObjects.Email("wesley_costa@outlook.com"),
                    Password = "123"
                });

                await _userRepository.Commit();
            }
            catch (Exception ex)
            {
                return CustomResponse(ex.ToString());
            }

            return CustomResponse(await _userRepository.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("get-by-email")]
        public async Task<IActionResult> GetByEmail()
        {
            return CustomResponse(await _userQueries.GetUserByEmail("wesley_costa@outlook.com"));
        }

        [AllowAnonymous]
        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessages()
        {
            var message = $"Messagem {new Random().Next(0, int.MaxValue - 1)}";
            await _hub.Clients.All.SendAsync("NotificationAll", message);
            return CustomResponse(message);
        }
    }
}
