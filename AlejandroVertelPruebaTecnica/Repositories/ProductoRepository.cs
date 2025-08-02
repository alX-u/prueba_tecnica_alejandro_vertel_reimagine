using AlejandroVertelPruebaReImagine.Data;
using AlejandroVertelPruebaReImagine.Models.Entities;
using AlejandroVertelPruebaReImagine.Repositories.IRepositories;

namespace AlejandroVertelPruebaTecnica.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Producto CreateProducto(Producto producto)
        {
            _db.Productos.Add(producto);
            return producto;
        }

        public bool DeleteProducto(int id)
        {
            var producto = _db.Productos.Find(id);
            if (producto == null)
                return false;

            _db.Productos.Remove(producto);
            return true;
        }

        public Producto GetProducto(int id)
        {
            return _db.Productos.FirstOrDefault(u => u.Id == id)!;
        }

        public ICollection<Producto> GetProductosFiltered(string? search, int? pageNumber, int? pageSize, out int totalItems)
        {
            var query = _db.Productos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p => p.Nombre.Contains(search) || p.Descripcion.Contains(search));
            }

            totalItems = query.Count();

            // Paginación
            int page = pageNumber ?? 1;
            int size = pageSize ?? 3;
            query = query.Skip((page - 1) * size).Take(size);

            return query.ToList();
        }

        public Producto UpdateProducto(Producto producto)
        {
            _db.Productos.Update(producto);
            return producto;
        }
    }
}
