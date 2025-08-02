using System.ComponentModel.DataAnnotations;

namespace AlejandroVertelPruebaReImagine.Models.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public double Precio { get; set; }

        [Required]
        public string Descripcion { get; set; }
    }
}
