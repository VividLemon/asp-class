using Lab_06.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public async Task DeleteCommentAsync(Comment comment)
        {
            comment.IsDeleted = true;
            Context.Update(comment);
            await Context.SaveChangesAsync();
        }
        public async Task<Comment> SaveCommentAsync(Comment comment)
        {
            await Context.AddAsync(comment);
            await Context.SaveChangesAsync();
            return comment;
        }
    }
}
