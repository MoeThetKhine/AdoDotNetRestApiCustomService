namespace AdoDotNetRestApiCustomService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdoDotNetController : ControllerBase
	{
		private readonly AdoDotNetService _adoDotNetService;

		public AdoDotNetController(AdoDotNetService adoDotNetService)
		{
			_adoDotNetService = adoDotNetService;
		}

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
	}
}
