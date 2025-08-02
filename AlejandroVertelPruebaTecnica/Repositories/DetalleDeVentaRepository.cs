using AlejandroVertelPruebaReImagine.Data;
using AlejandroVertelPruebaReImagine.Models.Entities;
using AlejandroVertelPruebaReImagine.Repositories.IRepositories;

namespace AlejandroVertelPruebaTecnica.Repositories
{
    public class DetalleDeVentaRepository : IDetalleDeVentaRepository
    {
        private readonly ApplicationDbContext _db;

        public DetalleDeVentaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<DetalleDeVenta> GetDetallesDeVenta(int ventaId, int? pageNumber, int? pageSize, out int totalItems)
        {
            var query = _db.DetallesDeVenta
                .Where(d => d.VentaId == ventaId)
                .AsQueryable();

            totalItems = query.Count();

            int page = pageNumber ?? 1;
            int size = pageSize ?? 3;
            query = query.OrderBy(d => d.Id).Skip((page - 1) * size).Take(size);

            return query.ToList();
        }

        public DetalleDeVenta GetDetalleDeVentaPorId(int ventaId, DetalleDeVenta detalleDeVenta)
        {
            return _db.DetallesDeVenta
                .FirstOrDefault(d => d.VentaId == ventaId && d.Id == detalleDeVenta.Id)!;
        }

        public DetalleDeVenta UpdateDetalleDeVenta(int ventaId, DetalleDeVenta detalleDeVenta)
        {
            var detalle = _db.DetallesDeVenta
                .FirstOrDefault(d => d.VentaId == ventaId && d.Id == detalleDeVenta.Id);

            if (detalle == null)
                return null;

            detalle.ProductoId = detalleDeVenta.ProductoId;
            detalle.Cantidad = detalleDeVenta.Cantidad;
            detalle.PrecioUnitario = detalleDeVenta.PrecioUnitario;
            detalle.Total = detalleDeVenta.Total;

            _db.DetallesDeVenta.Update(detalle);
            return detalle;
        }

        public bool DeleteDetalleDeVenta(int ventaId, DetalleDeVenta detalleDeVenta)
        {
            var detalle = _db.DetallesDeVenta
                .FirstOrDefault(d => d.VentaId == ventaId && d.Id == detalleDeVenta.Id);

            if (detalle == null)
                return false;

            _db.DetallesDeVenta.Remove(detalle);
            return true;
        }
    }
}
