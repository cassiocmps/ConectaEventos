using Microsoft.AspNetCore.Mvc;
using ConectaEventos.Services;

namespace ConectaEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocaisController : ControllerBase
    {
        private readonly LocalService _localService;

        public LocaisController(LocalService localService)
        {
            _localService = localService;
        }

        [HttpGet]
        public IActionResult GetAllLocais()
        {
            var locais = _localService.GetAllLocais();

            if (locais != null && locais.Count > 0)
            {
                return Ok(locais);
            }

            return NotFound("Nenhum local cadastrado.");
        }

    }
}
