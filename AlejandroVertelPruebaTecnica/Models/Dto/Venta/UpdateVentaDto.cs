using System.ComponentModel.DataAnnotations;

namespace AlejandroVertelPruebaReImagine.Models.Dto.Venta
{
    public class UpdateVentaDto
    {
        public int? UsuarioId { get; set; }

        public DateTime? Fecha { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El total debe ser mayor o igual a 0.")]
        public double? Total { get; set; }

        public UpdateVentaDto()
        {

        }
    }
}
