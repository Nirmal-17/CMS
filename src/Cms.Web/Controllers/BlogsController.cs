using Cms.Application.Models;
using Cms.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Controllers;

public class BlogsController : Controller
{
    private readonly IBlogService _blogs;

    public BlogsController(IBlogService blogs)
    {
        _blogs = blogs;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var posts = await _blogs.ListAsync(cancellationToken);
        return View(posts);
    }

    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var post = await _blogs.GetAsync(id, cancellationToken);
        return post is null ? NotFound() : View(post);
    }

    [HttpGet]
    public IActionResult Create() => View(new BlogPostInput());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BlogPostInput input, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(input);
        }

        var post = await _blogs.CreateAsync(input, cancellationToken);
        return RedirectToAction(nameof(Details), new { id = post.Id });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
    {
        var post = await _blogs.GetAsync(id, cancellationToken);
        if (post is null)
        {
            return NotFound();
        }

        return View(new BlogPostInput
        {
            Title = post.Title,
            Summary = post.Summary,
            Content = post.Content,
            AuthorName = post.AuthorName
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, BlogPostInput input, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(input);
        }

        var post = await _blogs.UpdateAsync(id, input, cancellationToken);
        return post is null ? NotFound() : RedirectToAction(nameof(Details), new { id });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var post = await _blogs.GetAsync(id, cancellationToken);
        return post is null ? NotFound() : View(post);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
    {
        await _blogs.DeleteAsync(id, cancellationToken);
        return RedirectToAction(nameof(Index));
    }
}
