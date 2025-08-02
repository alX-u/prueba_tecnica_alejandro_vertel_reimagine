using System.ComponentModel.DataAnnotations;

namespace AlejandroVertelPruebaReImagine.Models.Dto.Producto
{
    public class UpdateProductoDto
    {

        [MaxLength(50, ErrorMessage = "La longitud máxima del nombre es de 50 caracteres")]
        public string? Nombre { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El valor del producto tiene que ser mayor o igual que 0")]
        public double? Precio { get; set; }

        public string? Descripcion { get; set; }
    }
}
