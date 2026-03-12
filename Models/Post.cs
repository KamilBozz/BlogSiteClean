using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Excerpt => Content.Length > 100 ? Content.Substring(0, 100) + "..." : Content;

    public int AuthorId { get; set; }
    public Author Author { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}