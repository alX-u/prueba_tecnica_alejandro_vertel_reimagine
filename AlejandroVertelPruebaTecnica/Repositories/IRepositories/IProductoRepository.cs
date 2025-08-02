using AlejandroVertelPruebaReImagine.Models.Entities;

namespace AlejandroVertelPruebaReImagine.Repositories.IRepositories
{
    public interface IProductoRepository
    {
        Producto CreateProducto(Producto producto);

        ICollection<Producto> GetProductosFiltered(string? search, int? pageNumber, int? pageSize, out int totalItems);

        Producto GetProducto(int id);

        Producto UpdateProducto(Producto producto);

        bool DeleteProducto(int id);
    }
}
