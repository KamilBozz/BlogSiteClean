using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using BlogSite.Data;
using BlogSite.Models;

namespace BlogSite.Pages;

public class IndexModel : PageModel
{
    private readonly BlogContext _context;

    public IndexModel(BlogContext context)
    {
        _context = context;
    }

    public List<Post> Posts { get; set; }

    public Dictionary<string, List<Post>> Categories { get; set; }

    public async Task OnGetAsync()
    {
        Posts = await _context.Posts
            .Include(p => p.Author)
            .Include(p => p.Category)
            .ToListAsync();

        Categories = Posts
            .GroupBy(p => p.Category.Name)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
}
