using AutoMapper;
using Orangotango.Business.Models;
using Orangotango.Business.ViewModels;

namespace Orangotango.Business.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            AccountMapper();
        }

        private void AccountMapper()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
