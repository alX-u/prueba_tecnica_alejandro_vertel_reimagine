using AlejandroVertelPruebaReImagine.Data;
using AlejandroVertelPruebaReImagine.Repositories.IRepositories;

namespace AlejandroVertelPruebaReImagine.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }
}
