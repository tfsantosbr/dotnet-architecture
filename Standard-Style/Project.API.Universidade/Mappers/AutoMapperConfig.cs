using AutoMapper;

namespace Project.API.Universidade.Mappers
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EstudantesProfile>();
            });
        }
    }
}