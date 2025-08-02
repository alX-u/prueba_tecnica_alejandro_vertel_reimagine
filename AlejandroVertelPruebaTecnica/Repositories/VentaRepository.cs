using AlejandroVertelPruebaReImagine.Data;
using AlejandroVertelPruebaReImagine.Models.Dto.DetalleDeVenta;
using AlejandroVertelPruebaReImagine.Models.Dto.DetalleDeVenta.Response;
using AlejandroVertelPruebaReImagine.Models.Entities;
using AlejandroVertelPruebaReImagine.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace AlejandroVertelPruebaTecnica.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        private readonly ApplicationDbContext _db;

        public VentaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public VentaConDetalleResponseDto CreateVentaConDetalle(CreateVentaConDetalleDto dto)
        {
            var usuario = _db.Usuarios.Find(dto.UsuarioId);
            if (usuario == null)
                throw new ArgumentException("Usuario no encontrado");

            var venta = new Venta
            {
                UsuarioId = usuario.Id,
                Fecha = DateTime.UtcNow
            };
            _db.Ventas.Add(venta);
            _db.SaveChanges();

            double totalVenta = 0;

            for (int i = 0; i < dto.ProductosId.Count; i++)
            {
                var producto = _db.Productos.Find(dto.ProductosId[i]);
                if (producto == null)
                    throw new ArgumentException($"Producto con ID {dto.ProductosId[i]} no encontrado");

                int cantidad = dto.Cantidad[i];
                double precioUnitario = producto.Precio;
                double total = cantidad * precioUnitario;
                totalVenta += total;

                var detalle = new DetalleDeVenta
                {
                    ProductoId = producto.Id,
                    VentaId = venta.Id,
                    Cantidad = cantidad,
                    PrecioUnitario = precioUnitario,
                    Total = total
                };
                _db.DetallesDeVenta.Add(detalle);
            }

            _db.SaveChanges();

            return new VentaConDetalleResponseDto
            {
                Id = venta.Id,
                UsuarioId = usuario.Id,
                NombreUsuario = usuario.Nombre,
                Fecha = venta.Fecha ?? DateTime.UtcNow,
                Total = totalVenta
            };
        }

        public bool DeleteVenta(int id)
        {
            var venta = _db.Ventas
                .Include(v => v.DetallesDeVenta)
                .FirstOrDefault(v => v.Id == id);

            if (venta == null)
                return false;

            // Elimina los detalles asociados primero si la relación no es en cascada
            var detalles = _db.DetallesDeVenta.Where(d => d.VentaId == id).ToList();
            if (detalles.Any())
                _db.DetallesDeVenta.RemoveRange(detalles);

            _db.Ventas.Remove(venta);
            _db.SaveChanges();
            return true;
        }

        public Venta GetVenta(int id)
        {
            return _db.Ventas
                .Include(v => v.Usuario)
                .FirstOrDefault(v => v.Id == id);
        }

        public ICollection<Venta> GetVentasFiltered(DateTime? fechaInicio, DateTime? fechaFin, string? search, int? pageNumber, int? pageSize, out int totalItems)
        {
            var query = _db.Ventas
                .Include(v => v.Usuario)
                .AsQueryable();

            if (fechaInicio.HasValue)
                query = query.Where(v => v.Fecha >= fechaInicio.Value);

            if (fechaFin.HasValue)
                query = query.Where(v => v.Fecha <= fechaFin.Value);

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(v => v.Usuario.Nombre.Contains(search) || v.Usuario.DNI.Contains(search));

            totalItems = query.Count();

            int page = pageNumber ?? 1;
            int size = pageSize ?? 3;
            query = query.OrderBy(v => v.Id).Skip((page - 1) * size).Take(size);

            return query.ToList();
        }

        public Venta UpdateVenta(Venta venta)
        {
            var existing = _db.Ventas.Find(venta.Id);
            if (existing == null)
                return null;

            existing.UsuarioId = venta.UsuarioId;
            existing.Fecha = venta.Fecha;

            _db.Ventas.Update(existing);
            _db.SaveChanges();
            return existing;
        }
    }
}
