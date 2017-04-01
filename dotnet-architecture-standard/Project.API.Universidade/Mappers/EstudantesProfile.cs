using AutoMapper;
using Project.API.Universidade.Models.Estudante;
using Project.Models.Universidade.Entities;

namespace Project.API.Universidade.Mappers
{
    public class EstudantesProfile : Profile
    {
        public EstudantesProfile()
        {
            CreateMap<Estudante, EstudanteModel>();
            CreateMap<Estudante, EstudanteGetModel>();
            CreateMap<Estudante, EstudanteListItemModel>();
            CreateMap<EstudanteModel, Estudante>();
        }
    }
}