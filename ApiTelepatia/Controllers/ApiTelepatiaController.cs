using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ApiTelepatia.Controllers
{
    [ApiController]
    public class ExternaController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExternaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // -----------------------------
        // GET api/externa/usuarios
        // -----------------------------
        [HttpGet("auth/validate")]
        public async Task<IActionResult> GetUsuarios()
        {
            var client = _httpClientFactory.CreateClient("ApiExterna");

            var response = await client.GetAsync("api/v1/auth/validate");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error consumiendo API externa");

            var contenido = await response.Content.ReadAsStringAsync();

            return Ok(contenido);
        }
    }
}
