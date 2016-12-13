using AutoMapper;
using Project.API.Core.Models.Usuario;
using Project.Models.Core.Entities;

namespace Project.API.Core.Mappers
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            CreateMap<Usuario, UsuarioModel>();
            CreateMap<Usuario, UsuarioGetModel>();
            CreateMap<Usuario, UsuarioListItemModel>();
            CreateMap<UsuarioPostModel, Usuario>()
                .ForMember(o => o.UserName, d => d.MapFrom(e => e.Email))
                .ForMember(o => o.Senha, d => d.MapFrom(e => e.Senha));
        }
    }
}