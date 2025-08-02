using AlejandroVertelPruebaReImagine.Models.Entities;

namespace AlejandroVertelPruebaReImagine.Repositories.IRepositories
{
    public interface IDetalleDeVentaRepository
    {
        ICollection<DetalleDeVenta> GetDetallesDeVenta(int ventaId);

        DetalleDeVenta GetDetalleDeVentaPorId(int ventaId, DetalleDeVenta detalleDeVenta);

        DetalleDeVenta UpdateDetalleDeVenta(int ventaId, DetalleDeVenta detalleDeVenta);

        bool DeleteDetalleDeVenta(int ventaId, DetalleDeVenta detalleDeVenta);
    }
}
