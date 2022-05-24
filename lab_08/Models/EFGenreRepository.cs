using Lab_06.Data;
using System.Linq;
namespace Lab_06.Models
{
    public class EFGenreRepository: IGenreRepository
    {
        private ApplicationDbContext Context;
        public EFGenreRepository(ApplicationDbContext ctx)
        {
            Context = ctx;
        }
        public IQueryable<Genre> Genres => Context.Genres;
    }
}
