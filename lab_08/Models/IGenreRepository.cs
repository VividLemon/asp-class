using System.Linq;
namespace Lab_06.Models
{
    public interface IGenreRepository
    {
        IQueryable<Genre> Genres { get; }
    }
}
