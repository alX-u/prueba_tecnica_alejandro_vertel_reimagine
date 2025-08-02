using System.ComponentModel.DataAnnotations;

namespace AlejandroVertelPruebaReImagine.Models.Dto.DetalleDeVenta
{
    public class UpdateDetalleDeVentaDto
    {
        public int? ProductoId { get; set; }

        public int? VentaId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        public int? Cantidad { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor o igual a 0.")]
        public double? PrecioUnitario { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El total debe ser mayor o igual a 0.")]
        public double? Total { get; set; }
    }
}
