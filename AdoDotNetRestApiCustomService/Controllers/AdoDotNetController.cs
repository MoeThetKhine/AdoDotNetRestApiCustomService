using Microsoft.AspNetCore.Mvc;

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
	}
}
