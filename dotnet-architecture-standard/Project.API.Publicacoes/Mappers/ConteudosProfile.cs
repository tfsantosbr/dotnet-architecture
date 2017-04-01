using AutoMapper;
using Project.API.Publicacoes.Models.Conteudo;
using Project.Models.Publicacoes.Entities;

namespace Project.API.Publicacoes.Mappers
{
    public class ConteudosProfile : Profile
    {
        public ConteudosProfile()
        {
            CreateMap<Conteudo, ConteudoModel>();
            CreateMap<Conteudo, ConteudoGetModel>();
            CreateMap<Conteudo, ConteudoListItemModel>();
            CreateMap<ConteudoModel, Conteudo>();
        }
    }
}