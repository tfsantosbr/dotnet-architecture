using AutoMapper;

namespace Project.API.Publicacoes.Mappers
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ConteudosProfile>();
            });
        }
    }
}