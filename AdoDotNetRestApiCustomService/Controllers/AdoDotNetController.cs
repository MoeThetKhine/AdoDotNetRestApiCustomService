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

}
