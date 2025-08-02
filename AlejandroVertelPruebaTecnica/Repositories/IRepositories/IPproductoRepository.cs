using AlejandroVertelPruebaReImagine.Models.Entities;

namespace AlejandroVertelPruebaReImagine.Repositories.IRepositories
{
    public interface IPproductoRepository
    {
        Producto CreateProducto(Producto producto);

        ICollection<Producto> GetProductosFiltered(string? search);

        Producto GetProducto(int id);

        Producto UpdateProducto(Producto producto);

        bool DeleteProducto(int id);
    }
}
