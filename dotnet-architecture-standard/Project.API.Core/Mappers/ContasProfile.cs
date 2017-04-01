using AutoMapper;
using Project.API.Core.Models.Conta;
using Project.Models.Core.Entities;

namespace Project.API.Core.Mappers
{
    public class ContasProfile : Profile
    {
        public ContasProfile()
        {
            CreateMap<Usuario, ContaModel>();
            CreateMap<Usuario, ContaGetModel>();
            CreateMap<ContaPostModel, Usuario>()
                .ForMember(o => o.UserName, d => d.MapFrom(e => e.Email))
                .ForMember(o => o.Senha, d => d.MapFrom(e => e.Senha));
        }
    }
}