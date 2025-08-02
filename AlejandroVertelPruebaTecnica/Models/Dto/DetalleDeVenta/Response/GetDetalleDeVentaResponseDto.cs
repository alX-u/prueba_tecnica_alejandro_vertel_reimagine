namespace AlejandroVertelPruebaTecnica.Models.Dto.DetalleDeVenta.Response
{
    public class GetDetalleDeVentaResponseDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int VentaId { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Total { get; set; }
    }
}
