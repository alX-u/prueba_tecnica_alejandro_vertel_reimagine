using AlejandroVertelPruebaReImagine.Models.Dto.Producto;
using AlejandroVertelPruebaReImagine.Models.Entities;
using AlejandroVertelPruebaReImagine.Repositories.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlejandroVertelPruebaTecnica.Controllers
{


    [Route("api/productos")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductoController(IProductoRepository productoRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        // GET: api/productos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get([FromQuery] string? search, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var productos = _productoRepository.GetProductosFiltered(search, pageNumber, pageSize, out int totalItems);

            return Ok(new
            {
                TotalItems = totalItems,
                PageNumber = pageNumber ?? 1,
                PageSize = pageSize ?? 3,
                Productos = productos
            });
        }

        // GET: api/productos/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var producto = _productoRepository.GetProducto(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        // POST: api/productos
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] CreateProductoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var producto = _mapper.Map<Producto>(dto);
            _productoRepository.CreateProducto(producto);
            _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        // PUT: api/productos/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] UpdateProductoDto dto)
        {
            var producto = _productoRepository.GetProducto(id);
            if (producto == null)
                return NotFound();

            _mapper.Map(dto, producto);
            _productoRepository.UpdateProducto(producto);
            _unitOfWork.SaveChanges();

            return Ok(producto);
        }

        // DELETE: api/productos/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deleted = _productoRepository.DeleteProducto(id);
            if (!deleted)
                return NotFound();

            _unitOfWork.SaveChanges();
            return Ok("Producto eliminado exitosamente");
        }
    }
}
