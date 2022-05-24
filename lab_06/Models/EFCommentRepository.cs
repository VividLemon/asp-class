using Lab_06.Data;
using System.Linq;
namespace Lab_06.Models
{
    public class EFCommentRepository : ICommentRepository
    {
        private ApplicationDbContext Context;
        public EFCommentRepository(ApplicationDbContext ctx)
        {
            Context = ctx;
        }
        public IQueryable<Comment> Comments => Context.Comments;
    }
}
