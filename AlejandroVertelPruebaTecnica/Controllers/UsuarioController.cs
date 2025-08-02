using AlejandroVertelPruebaReImagine.Models.Dto.Usuario;
using AlejandroVertelPruebaReImagine.Models.Entities;
using AlejandroVertelPruebaReImagine.Repositories.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlejandroVertelPruebaReImagine.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioController(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/usuarios
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromQuery] string? search, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var usuarios = _usuarioRepository.GetUsersFiltered(search, pageNumber, pageSize, out int totalItems);

            return Ok(new
            {
                TotalItems = totalItems,
                PageNumber = pageNumber ?? 1,
                PageSize = pageSize ?? 3,
                Usuarios = usuarios
            });
        }

        // GET: api/usuarios/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _usuarioRepository.GetUsuario(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // POST: api/usuarios
        [HttpPost]
        public IActionResult Post([FromBody] CreateUsuarioDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = _mapper.Map<Usuario>(dto);

            _usuarioRepository.CreateUsuario(usuario);
            _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] UpdateUsuarioDto dto)
        {
            var usuario = _usuarioRepository.GetUsuario(id);
            if (usuario == null)
                return NotFound();

            _mapper.Map(dto, usuario);

            _usuarioRepository.UpdateUsuario(usuario);
            _unitOfWork.SaveChanges();

            return Ok(usuario);
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            var deleted = _usuarioRepository.DeleteUsuario(id);
            if (!deleted)
                return NotFound();

            _unitOfWork.SaveChanges();
            return Ok("Usuario eliminado exitosamente");
        }
    }
}
