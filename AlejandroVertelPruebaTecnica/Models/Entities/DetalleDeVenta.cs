using System.ComponentModel.DataAnnotations;

namespace AlejandroVertelPruebaReImagine.Models.Entities
{
    public class DetalleDeVenta
    {
        [Key]
        public int Id { get; set; }

        public int[] ProductoId { get; set; }
        public Producto[] Producto { get; set; }

        public int[] VentaId { get; set; }
        public Venta[] Venta { get; set; }

        public int Cantidad { get; set; }

        public double PrecioUnitario { get; set; }

        public double Total { get; set; }

    }
}
