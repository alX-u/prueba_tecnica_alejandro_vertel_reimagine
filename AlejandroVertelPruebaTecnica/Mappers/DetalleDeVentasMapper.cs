using AlejandroVertelPruebaReImagine.Models.Dto.DetalleDeVenta;
using AlejandroVertelPruebaReImagine.Models.Entities;
using AlejandroVertelPruebaTecnica.Models.Dto.DetalleDeVenta.Response;
using AutoMapper;

namespace AlejandroVertelPruebaTecnica.Mappers
{
    public class DetalleDeVentasMapper : Profile
    {
        public DetalleDeVentasMapper()
        {
            CreateMap<DetalleDeVenta, GetDetalleDeVentaResponseDto>().ReverseMap();
            CreateMap<DetalleDeVenta, CreateVentaConDetalleDto>().ReverseMap();
        }
    }
}
