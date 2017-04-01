using AutoMapper;

namespace Project.API.Core.Mappers
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ContasProfile>();
                cfg.AddProfile<UsuariosProfile>();
            });
        }
    }
}