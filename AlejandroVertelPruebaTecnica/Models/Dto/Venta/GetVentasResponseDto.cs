using AlejandroVertelPruebaReImagine.Models.Entities;

namespace AlejandroVertelPruebaTecnica.Models.Dto.Venta
{
    public class GetVentasResponseDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
