namespace AdoDotNetRestApiCustomService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdoDotNetController : ControllerBase
{
	private readonly AdoDotNetService _adoDotNetService;

	public AdoDotNetController(AdoDotNetService adoDotNetService)
	{
		_adoDotNetService = adoDotNetService;
	}

	#region GetAllBlogs

	[HttpGet]
	public async Task<IActionResult> GetAllBlogs()
	{
		try
		{
			var blogs = await _adoDotNetService.QueryAsync<BlogModel>(Query.GetAllBlogsQuery);
			return Ok(blogs);
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Internal Server Error: {ex.Message}");
		}
	}

	#endregion

	#region CreateBlog

	[HttpPost]
	public async Task<IActionResult> CreateBlog([FromBody] BlogModel blog)
	{
		try
		{

			#region Validation

			if (blog is null)
			{
				return BadRequest("Please fill all field.");
			}
			if (string.IsNullOrWhiteSpace(blog.BlogTitle))
			{
				return BadRequest("Invalid Blog Data.");
			}
			if (string.IsNullOrWhiteSpace(blog.BlogAuthor))
			{
				return BadRequest("Invalid Blog Data");
			}
			if (string.IsNullOrWhiteSpace(blog.BlogContent))
			{
				return BadRequest("Invalid Blog Data");
			}

			#endregion

			var parameters = new List<SqlParameter>
			{
				new("@BlogTitle",blog.BlogTitle),
				new("@BlogAuthor",blog.BlogAuthor),
				new("@BlogContent",blog.BlogContent),
				new("@DeleteFlag", false),
			};

			int result = await _adoDotNetService.ExecuteAsync(Query.CreateBlogQuery, parameters.ToArray());
			return result > 0 ? Ok("Blog Created Successfully.") : StatusCode(500, "Failed to Create Blog");

		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Internal Server Error: {ex.Message}");
		}
	}

	#endregion

	#region UpdateBlog

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateBlog(int id, [FromBody] BlogModel blog)
	{
		try
		{

			#region Validation

			if (blog is null)
			{
				return BadRequest("Please fill all field.");
			}
			if (string.IsNullOrWhiteSpace(blog.BlogTitle))
			{
				return BadRequest("Invalid Blog Data.");
			}
			if (string.IsNullOrWhiteSpace(blog.BlogAuthor))
			{
				return BadRequest("Invalid Blog Data");
			}
			if (string.IsNullOrWhiteSpace(blog.BlogContent))
			{
				return BadRequest("Invalid Blog Data");
			}

			#endregion

			var parameters = new List<SqlParameter>
			{
				new("@BlogId", id),
				new("@BlogTitle", blog.BlogTitle),
				new("@BlogAuthor", blog.BlogAuthor),
				new("@BlogContent", blog.BlogContent)
			};

			int result = await _adoDotNetService.ExecuteAsync(Query.UpdateBlogQuery, parameters.ToArray());
			return result > 0 ? Ok("Blog updated successfully.") : NotFound("Blog not found.");

		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Internal Server Error: {ex.Message}");
		}
	}

	#endregion

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteBlog(int id)
	{
		try
		{
			var parameters = new List<SqlParameter>
			{
				new("@BlogId", id)
			};

			int result = await _adoDotNetService.ExecuteAsync(Query.DeleteBlogQuery, parameters.ToArray());
			return result > 0 ? Ok("Blog marked as deleted successfully.") : NotFound("Blog not found.");
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Internal server error: {ex.Message}");
		}
	}

}
