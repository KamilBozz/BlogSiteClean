using Microsoft.EntityFrameworkCore;
using BlogSite.Models;

namespace BlogSite.Data;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options) { }

    public DbSet<Post> Posts { get; set; } = default!; // database table

}