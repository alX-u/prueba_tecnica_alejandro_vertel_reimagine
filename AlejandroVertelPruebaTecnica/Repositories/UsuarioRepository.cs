using AlejandroVertelPruebaReImagine.Data;
using AlejandroVertelPruebaReImagine.Models.Entities;
using AlejandroVertelPruebaReImagine.Repositories.IRepositories;

namespace AlejandroVertelPruebaReImagine.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;

        public UsuarioRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateUsuario(Usuario usuario)
        {
            _db.Usuarios.Add(usuario);
            return true;
        }

        public bool DeleteUsuario(int id)
        {
            var usuario = _db.Usuarios.Find(id);
            if (usuario == null)
            {
                return false;
            }
            _db.Usuarios.Remove(usuario);
            return true;
        }

        public ICollection<Usuario> GetUsersFiltered(string? search, int? pageNumber, int? pageSize, out int totalItems)
        {
            int page = pageNumber ?? 1;
            int size = pageSize ?? 3;

            var query = _db.Usuarios.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(u =>
                    u.Nombre.Contains(search) ||
                    u.DNI.Contains(search)
                );
            }

            totalItems = query.Count();

            return query
                .OrderBy(u => u.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();
        }

        public Usuario GetUsuario(int id)
        {
            return _db.Usuarios.FirstOrDefault(u => u.Id == id)!;
        }

        public Usuario UpdateUsuario(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            return usuario;
        }
    }
}
