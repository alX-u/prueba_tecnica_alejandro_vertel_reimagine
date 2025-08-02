using AlejandroVertelPruebaReImagine.Models.Dto.DetalleDeVenta;
using AlejandroVertelPruebaReImagine.Models.Dto.DetalleDeVenta.Response;
using AlejandroVertelPruebaReImagine.Models.Entities;

namespace AlejandroVertelPruebaReImagine.Repositories.IRepositories
{
    public interface IVentasRepository
    {
        VentaConDetalleResponseDto CreateVentaConDetalle(CreateVentaConDetalleDto dto);
        ICollection<Venta> GetVentasFiltered(DateTime? fechaInicio, DateTime? fechaFin, string? search);
        Venta GetVenta(int id);
        Venta UpdateVenta(Venta venta);
        bool DeleteVenta(int id);
    }
}
