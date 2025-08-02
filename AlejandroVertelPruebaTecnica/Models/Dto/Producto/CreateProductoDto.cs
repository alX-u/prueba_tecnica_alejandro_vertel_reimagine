using System.ComponentModel.DataAnnotations;

namespace AlejandroVertelPruebaReImagine.Models.Dto.Producto
{
    public class CreateProductoDto
    {

        [Required(ErrorMessage = "El nombre es requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud máxima del nombre es de 50 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El valor del producto tiene que ser mayor o igual que 0")]
        public double Precio { get; set; }

        [Required]
        public string Descripcion { get; set; }
    }
}
