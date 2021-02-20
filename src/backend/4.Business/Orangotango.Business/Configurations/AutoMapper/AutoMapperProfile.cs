using AutoMapper;
using Orangotango.Business.Models;
using Orangotango.Business.ViewModels;
using Orangotango.Business.ViewModels.RoomTypes;
using Orangotango.Business.ViewModels.Users;

namespace Orangotango.Business.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            UserMapper();
            RoomTypeMapper();
        }

        private void UserMapper()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(viewModel => viewModel.Email, map => map.MapFrom(user => user.Email.Address));

            CreateMap<User, UserAuthViewModel>()
                .ForMember(viewModel => viewModel.Email, map => map.MapFrom(user => user.Email.Address));
        }

        private void RoomTypeMapper()
        {
            CreateMap<RoomType, RoomTypeViewModel>().ReverseMap();
        }
    }
}
