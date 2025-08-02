using AlejandroVertelPruebaTecnica.Models.Validadores;
using System.ComponentModel.DataAnnotations;

namespace AlejandroVertelPruebaReImagine.Models.Dto.DetalleDeVenta
{
    public class CreateVentaConDetalleDto
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Debe incluir al menos un producto.")]
        public List<int> ProductosId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [CantidadMayorACero(ErrorMessage = "Cada cantidad debe ser mayor a 0.")]
        public List<int> Cantidad { get; set; }
    }
}