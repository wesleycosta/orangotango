using AutoMapper;
using Orangotango.Business.Intefaces.Queries;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Business.ViewModels;
using Orangotango.Core.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orangotango.Business.Application.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly INotifier _notifier;

        public UserQueries(IUserRepository userRepository,
                           IMapper mapper,
                           INotifier notifier)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _notifier = notifier;
        }

        public async Task<UserViewModel> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(new Email(email));
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<List<UserViewModel>>(users);
        }

        public async Task<bool> HasEmail(string email)
        {
            if (!Email.IsValid(email))
            {
                _notifier.Notify("E-mail inválido");
                return false;
            }

            return await _userRepository.HasEmail(new Email(email));
        }
    }
}
