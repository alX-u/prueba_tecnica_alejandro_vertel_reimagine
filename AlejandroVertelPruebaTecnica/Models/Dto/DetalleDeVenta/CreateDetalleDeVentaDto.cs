using System.ComponentModel.DataAnnotations;

namespace AlejandroVertelPruebaReImagine.Models.Dto.DetalleDeVenta
{
    public class DetalleProductoVentaDto
    {
        [Required(ErrorMessage = "El ProductoId es obligatorio.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        public int Cantidad { get; set; }
    }

    public class CreateVentaConDetalleDto
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio.")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "El DNI debe tener entre 8 y 10 caracteres.")]
        public string DNI { get; set; }

        [Required(ErrorMessage = "Debe incluir al menos un producto.")]
        public List<DetalleProductoVentaDto> Productos { get; set; }
    }
}