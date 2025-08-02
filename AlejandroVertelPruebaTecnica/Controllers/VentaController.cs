using AlejandroVertelPruebaReImagine.Models.Dto.DetalleDeVenta;
using AlejandroVertelPruebaReImagine.Models.Entities;
using AlejandroVertelPruebaReImagine.Repositories.IRepositories;
using AlejandroVertelPruebaTecnica.Models.Dto.DetalleDeVenta.Response;
using AlejandroVertelPruebaTecnica.Models.Dto.Venta;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlejandroVertelPruebaTecnica.Controllers
{
    [Route("api/ventas")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IDetalleDeVentaRepository _detalleDeVentaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VentaController(
            IVentaRepository ventaRepository,
            IDetalleDeVentaRepository detalleDeVentaRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _detalleDeVentaRepository = detalleDeVentaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // VENTAS

        // GET /api/ventas
        [HttpGet]
        public IActionResult Get([FromQuery] DateTime? fechaInicio, [FromQuery] DateTime? fechaFin, [FromQuery] string? search, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var ventas = _ventaRepository.GetVentasFiltered(fechaInicio, fechaFin, search, pageNumber, pageSize, out int totalItems);
            var ventasDto = _mapper.Map<List<GetVentasResponseDto>>(ventas);
            return Ok(new
            {
                TotalItems = totalItems,
                PageNumber = pageNumber ?? 1,
                PageSize = pageSize ?? 3,
                Ventas = ventasDto
            });
        }

        // GET /api/ventas/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var venta = _ventaRepository.GetVenta(id);
            if (venta == null)
                return NotFound();

            var ventaDto = _mapper.Map<GetVentasResponseDto>(venta);
            return Ok(ventaDto);
        }

        // POST /api/ventas
        [HttpPost]
        public IActionResult Post([FromBody] CreateVentaConDetalleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ventaResponse = _ventaRepository.CreateVentaConDetalle(dto);
            _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = ventaResponse.Id }, ventaResponse);
        }

        // PUT /api/ventas/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateVentaDto dto)
        {
            var venta = _ventaRepository.GetVenta(id);
            if (venta == null)
                return NotFound();

            if (dto.UsuarioId.HasValue)
                venta.UsuarioId = dto.UsuarioId.Value;

            if (dto.Fecha.HasValue)
                venta.Fecha = dto.Fecha.Value;

            _ventaRepository.UpdateVenta(venta);
            _unitOfWork.SaveChanges();

            return Ok(venta);
        }

        // DELETE /api/ventas/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _ventaRepository.DeleteVenta(id);
            if (!deleted)
                return NotFound();

            _unitOfWork.SaveChanges();
            return Ok("Venta eliminada exitosamente");
        }

        // DETALLE DE VENTA

        // GET /api/ventas/{ventaId}/detalles
        [HttpGet("{ventaId}/detalles")]
        public IActionResult GetDetalles(int ventaId, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var detalles = _detalleDeVentaRepository.GetDetallesDeVenta(ventaId, pageNumber, pageSize, out int totalItems);
            return Ok(new
            {
                TotalItems = totalItems,
                PageNumber = pageNumber ?? 1,
                PageSize = pageSize ?? 3,
                Detalles = detalles
            });
        }

        // GET /api/ventas/{ventaId}/detalles/{id}
        [HttpGet("{ventaId}/detalles/{id}")]
        public IActionResult GetDetalle(int ventaId, int id)
        {
            var detalle = _detalleDeVentaRepository.GetDetallesDeVenta(ventaId, null, null, out _)
                .FirstOrDefault(d => d.Id == id);

            if (detalle == null)
                return NotFound();

            var detalleDto = _mapper.Map<GetDetalleDeVentaResponseDto>(detalle);
            return Ok(detalleDto);
        }


        // PUT /api/ventas/{ventaId}/detalles/{id}
        [HttpPut("{ventaId}/detalles/{id}")]
        public IActionResult PutDetalle(int ventaId, int id, [FromBody] UpdateDetalleDeVentaDto dto)
        {
            var detalle = _detalleDeVentaRepository.GetDetallesDeVenta(ventaId, null, null, out _)
                .FirstOrDefault(d => d.Id == id);

            if (detalle == null)
                return NotFound();

            if (dto.ProductoId.HasValue)
                detalle.ProductoId = dto.ProductoId.Value;
            if (dto.Cantidad.HasValue)
                detalle.Cantidad = dto.Cantidad.Value;
            if (dto.PrecioUnitario.HasValue)
                detalle.PrecioUnitario = dto.PrecioUnitario.Value;
            if (dto.Total.HasValue)
                detalle.Total = dto.Total.Value;

            var actualizado = _detalleDeVentaRepository.UpdateDetalleDeVenta(ventaId, detalle);
            if (actualizado == null)
                return NotFound();

            _unitOfWork.SaveChanges();
            var detalleDto = _mapper.Map<GetDetalleDeVentaResponseDto>(actualizado);
            return Ok(detalleDto);
        }

        // DELETE /api/ventas/{ventaId}/detalles/{id}
        [HttpDelete("{ventaId}/detalles/{id}")]
        public IActionResult DeleteDetalle(int ventaId, int id)
        {
            var detalle = new DetalleDeVenta { Id = id };
            var deleted = _detalleDeVentaRepository.DeleteDetalleDeVenta(ventaId, detalle);
            if (!deleted)
                return NotFound();

            _unitOfWork.SaveChanges();
            return Ok("Detalle de venta eliminado exitosamente");
        }
    }
}
