using System.ComponentModel.DataAnnotations;

namespace AlejandroVertelPruebaReImagine.Models.Entities
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public DateTime? Fecha { get; set; }

        public double Total { get; set; }

        public Venta()
        {
            Fecha ??= DateTime.Now;
        }
    }
}
