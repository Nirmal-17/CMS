using Cms.Application.Models;
using Cms.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Controllers.Api;

[ApiController]
[Route("api/blogs")]
[Produces("application/json")]
public class BlogsApiController : ControllerBase
{
    private readonly IBlogService _blogs;

    public BlogsApiController(IBlogService blogs)
    {
        _blogs = blogs;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<BlogPostDto>>> GetAll(CancellationToken cancellationToken) =>
        Ok(await _blogs.ListAsync(cancellationToken));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BlogPostDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var post = await _blogs.GetAsync(id, cancellationToken);
        return post is null ? NotFound() : Ok(post);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BlogPostDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<BlogPostDto>> Create(BlogPostInput input, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var post = await _blogs.CreateAsync(input, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<BlogPostDto>> Update(int id, BlogPostInput input, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var post = await _blogs.UpdateAsync(id, input, cancellationToken);
        return post is null ? NotFound() : Ok(post);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await _blogs.DeleteAsync(id, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}
