using Bogus;
using Microsoft.EntityFrameworkCore;
using BlogSite.Models;

namespace BlogSite.Data;

public static class DbInitializer
{
    public static void Initialize(BlogContext context)
    {
        if(context.Posts.Any())
        {
            return;
        }

        var postId = 1;

        var postFaker = new Faker<Post>()
            .Rules((f, p) =>
            {
                p.Id = postId++;
                p.Title = f.Lorem.Sentence();
                p.Content = f.Lorem.Paragraphs(5);
            });

        List<Post> posts = postFaker.Generate(5);

        context.Posts.AddRange(posts);
        context.SaveChanges();
    }
}