using AutoMapper;
using Orangotango.Business.Configurations.AutoMapper;

namespace Orangotango.Tests.Infrastructure
{
    public static class AutoMapperSingleton
    {
        private static IMapper _mapper;
        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    var mappingConfig = new MapperConfiguration(config =>
                    {
                        config.AddMaps(typeof(AutoMapperProfile));
                    });

                    _mapper = mappingConfig.CreateMapper();
                }

                return _mapper;
            }
        }
    }
}
