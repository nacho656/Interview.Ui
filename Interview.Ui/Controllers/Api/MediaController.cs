using Interview.Ui.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Ui.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly GenericApiProxy api;

        public MediaController(GenericApiProxy proxyApi)
        {
            this.api = proxyApi;
        }

        [HttpGet("GetMedia")]
        public async Task<IActionResult> GetMedia(CancellationToken cancellationToken)
        {
            return Ok(await api.Get("api/media", cancellationToken));
        }

        [HttpGet("GetGenre")]
        public async Task<IActionResult> GetGenre(CancellationToken cancellationToken)
        {
            return Ok(await api.Get("api/genre", cancellationToken));

        }

        //Todo: 01 - Add Media Save method
    }
}
