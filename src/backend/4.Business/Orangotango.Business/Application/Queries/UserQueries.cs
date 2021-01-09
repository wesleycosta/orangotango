using AutoMapper;
using Orangotango.Business.Intefaces.Queries;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Business.ViewModels;
using System.Threading.Tasks;

namespace Orangotango.Business.Application.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserQueries(IUserRepository userRepository,
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(new Email(email));
            return _mapper.Map<UserViewModel>(user);
        }
    }
}
