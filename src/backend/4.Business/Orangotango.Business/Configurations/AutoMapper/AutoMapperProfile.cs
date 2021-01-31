using AutoMapper;
using Orangotango.Business.Models;
using Orangotango.Business.ViewModels;

namespace Orangotango.Business.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            UserMapper();
        }

        private void UserMapper()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(viewModel => viewModel.Email, map => map.MapFrom(user => user.Email.Address));
        }
    }
}
