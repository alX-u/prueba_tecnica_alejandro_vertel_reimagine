using AlejandroVertelPruebaReImagine.Models.Entities;

namespace AlejandroVertelPruebaReImagine.Repositories.IRepositories
{
    public interface IUsuarioRepository
    {
        bool CreateUsuario(Usuario usuario);

        ICollection<Usuario> GetUsersFiltered(string? search, int? pageNumber, int? pageSize, out int totalItems);

        Usuario GetUsuario(int id);

        Usuario UpdateUsuario(Usuario usuario);

        bool DeleteUsuario(int id);

    }
}
