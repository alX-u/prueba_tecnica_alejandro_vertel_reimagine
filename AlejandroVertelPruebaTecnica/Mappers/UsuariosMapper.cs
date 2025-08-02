using AlejandroVertelPruebaReImagine.Models.Dto.Usuario;
using AlejandroVertelPruebaReImagine.Models.Entities;
using AutoMapper;

namespace AlejandroVertelPruebaTecnica.Mappers
{
    public class UsuariosMapper : Profile
    {
        public UsuariosMapper()
        {
            CreateMap<Usuario, CreateUsuarioDto>().ReverseMap();
            CreateMap<Usuario, UpdateUsuarioDto>().ReverseMap();
        }
    }
}
