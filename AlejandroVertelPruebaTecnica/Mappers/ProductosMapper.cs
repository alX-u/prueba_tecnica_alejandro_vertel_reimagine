using AlejandroVertelPruebaReImagine.Models.Dto.Producto;
using AlejandroVertelPruebaReImagine.Models.Entities;
using AutoMapper;

namespace AlejandroVertelPruebaTecnica.Mappers
{
    public class ProductosMapper : Profile
    {
        public ProductosMapper()
        {

            CreateMap<Producto, CreateProductoDto>().ReverseMap();
            CreateMap<Producto, UpdateProductoDto>().ReverseMap();
        }
    }
}
