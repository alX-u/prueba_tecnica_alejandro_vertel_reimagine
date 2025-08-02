using System.ComponentModel.DataAnnotations;

namespace AlejandroVertelPruebaReImagine.Models.Dto.Usuario
{
    public class UpdateUsuarioDto
    {
        [MaxLength(50, ErrorMessage = "El número máximo de caracteres es 50.")]
        public string? Nombre { get; set; }

        [StringLength(10, MinimumLength = 8, ErrorMessage = "El DNI debe entre 8 y 10 caracteres.")]
        public string? DNI { get; set; }

    }
}
