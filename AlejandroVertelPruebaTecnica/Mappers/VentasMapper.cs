using AlejandroVertelPruebaReImagine.Models.Entities;
using AlejandroVertelPruebaTecnica.Models.Dto.Venta;
using AutoMapper;

namespace AlejandroVertelPruebaTecnica.Mappers
{
    public class VentasMapper : Profile
    {
        public VentasMapper()
        {
            CreateMap<Venta, GetVentasResponseDto>().ReverseMap();
            CreateMap<Venta, UpdateVentaDto>().ReverseMap();
        }
    }
}
