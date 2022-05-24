using Microsoft.EntityFrameworkCore;
using Lab_06.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Lab_06.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<VideoGenre> VideoGenres { get; set; }
        public DbSet<LikedVideo> LikedVideos { get; set; }
        #region Required
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Comment>().HasQueryFilter(el => el.IsDeleted == false);
            builder.Entity<Video>().HasQueryFilter(el => el.IsDeleted == false);
        }
        #endregion
    }
}
