namespace AlejandroVertelPruebaReImagine.Models.Dto.DetalleDeVenta.Response
{
    public class VentaConDetalleResponseDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime Fecha { get; set; }

        public double Total { get; set; }
    }
}
