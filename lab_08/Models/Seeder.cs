using Lab_06.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
namespace Lab_06.Models
{
    public static class Seeder
    {
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync();
            UserManager<User> userManager = app.ApplicationServices.GetRequiredService<UserManager<User>>();
            RoleManager<Role> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<Role>>();
            if (!await roleManager.Roles.AnyAsync())
            {
                await roleManager.CreateAsync(new Role { Name = "Admin" });
                await roleManager.CreateAsync(new Role { Name = "Standard" });
            }
            User admin = new User { UserName = "Admin" };
            User user = new User { UserName = "User" };
            if (!await userManager.Users.AnyAsync())
            {
                IdentityResult identityAdmin = await userManager.CreateAsync(admin, "Admin1!");
                if (identityAdmin.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
                IdentityResult identityUser = await userManager.CreateAsync(user, "User1!");
                if (identityUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Standard");
                }
            }
            Video video = new Video { Name = "Video 1", Price = 100, Description = "Some video desc", ImagePath = "https://www.pngall.com/wp-content/uploads/2016/05/Orange-Free-PNG-Image.png", Path = "https://www.youtube.com/watch?v=P5utCp_EhXA&feature=emb_logo&ab_channel=Tasty", EmbedHtml = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/P5utCp_EhXA\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>", User = admin };
            Video video2 = new Video { Name = "Video 2", Price = 100, Description = "Some second video", ImagePath = "https://www.pngall.com/wp-content/uploads/2016/05/Orange-Free-PNG-Image.png", Path = "https://www.youtube.com/watch?v=mFvIBlgjFzA&list=UUCLFxVP-PFDk7yZj208aAgg&ab_channel=MashupZone", EmbedHtml = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/mFvIBlgjFzA\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>", User = admin };
            Video video3 = new Video { Name = "Video 3", Price = 100, Description = "Some video desc", ImagePath = "https://www.pngall.com/wp-content/uploads/2016/05/Orange-Free-PNG-Image.png", Path = "https://www.youtube.com/watch?v=P5utCp_EhXA&feature=emb_logo&ab_channel=Tasty", EmbedHtml = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/P5utCp_EhXA\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>", User = admin };
            Video video4 = new Video { Name = "Video 4", Price = 100, Description = "Some second video", ImagePath = "https://www.pngall.com/wp-content/uploads/2016/05/Orange-Free-PNG-Image.png", Path = "https://www.youtube.com/watch?v=mFvIBlgjFzA&list=UUCLFxVP-PFDk7yZj208aAgg&ab_channel=MashupZone", EmbedHtml = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/mFvIBlgjFzA\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>", User = admin };
            Video video5 = new Video { Name = "Video 5", Price = 100, Description = "Some video desc", ImagePath = "https://www.pngall.com/wp-content/uploads/2016/05/Orange-Free-PNG-Image.png", Path = "https://www.youtube.com/watch?v=P5utCp_EhXA&feature=emb_logo&ab_channel=Tasty", EmbedHtml = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/P5utCp_EhXA\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>", User = admin };
            Video video6 = new Video { Name = "Video 6", Price = 100, Description = "Some second video", ImagePath = "https://www.pngall.com/wp-content/uploads/2016/05/Orange-Free-PNG-Image.png", Path = "https://www.youtube.com/watch?v=mFvIBlgjFzA&list=UUCLFxVP-PFDk7yZj208aAgg&ab_channel=MashupZone", EmbedHtml = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/mFvIBlgjFzA\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>", User = admin };
            if (!await context.Videos.AnyAsync())
            {
                await context.Videos.AddRangeAsync(video, video2, video3, video4, video5, video6);
                await context.SaveChangesAsync();
            }
            Genre genre = new Genre { Name = "first genre", Description = "First genre description" };
            Genre secondGenre = new Genre { Name = "Second genre", Description = "Second genre description" };
            if (!await context.Genres.AnyAsync())
            {
                await context.Genres.AddRangeAsync(genre, secondGenre);
                await context.SaveChangesAsync();
            }
            List<VideoGenre> videoGenres = new List<VideoGenre>()
            {
                new VideoGenre { Video = video, Genre = genre },
                new VideoGenre { Video = video, Genre = secondGenre },
                new VideoGenre { Video = video2, Genre = genre },
                new VideoGenre { Video = video2, Genre = secondGenre },
                new VideoGenre { Video = video3, Genre = genre },
                new VideoGenre { Video = video3, Genre = secondGenre },
                new VideoGenre { Video = video4, Genre = genre },
                new VideoGenre { Video = video4, Genre = secondGenre },
                new VideoGenre { Video = video5, Genre = genre },
                new VideoGenre { Video = video5, Genre = secondGenre },
                new VideoGenre { Video = video6, Genre = genre },
                new VideoGenre { Video = video6, Genre = secondGenre }
            };
            if (!await context.VideoGenres.AnyAsync())
            {
                await context.VideoGenres.AddRangeAsync(videoGenres);
                await context.SaveChangesAsync();
            }
            Comment comment = new Comment { Text = "Test comment 1", Video = video, User = admin };
            Comment comment2 = new Comment { Text = "Second test comment", User = user, Video = video };
            if (!await context.Comments.AnyAsync())
            {
                await context.Comments.AddRangeAsync(comment, comment2, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video }, new Comment { Text = "Second test comment", User = user, Video = video });
                await context.SaveChangesAsync();
            }
        }
    }
}
