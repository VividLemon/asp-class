using System.Linq;
using System.Threading.Tasks;
namespace Lab_06.Models
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }
        Task DeleteCommentAsync(Comment comment);
        Task<Comment> SaveCommentAsync(Comment comment);
    }
}
