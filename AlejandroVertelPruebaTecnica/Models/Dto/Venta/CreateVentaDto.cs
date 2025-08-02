using System.ComponentModel.DataAnnotations;

namespace AlejandroVertelPruebaReImagine.Models.Dto.Venta
{
    public class CreateVentaDto
    {

        [Required(ErrorMessage = "El usuario es obligatorio.")]
        public int UsuarioId { get; set; }

        public DateTime? Fecha { get; set; }

        [Required(ErrorMessage = "El total es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El total debe ser mayor o igual a 0.")]
        public double Total { get; set; }

        public CreateVentaDto()
        {

        }
    }
}
