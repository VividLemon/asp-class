using System.Linq;
namespace Lab_06.Models
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }
    }
}
