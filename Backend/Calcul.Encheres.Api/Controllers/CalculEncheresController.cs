using Calcul.Encheres.Api.Entites;
using Calcul.Encheres.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calcul.Encheres.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculEncheresController : ControllerBase
    {
        private readonly ICalculEncheresServices _calculEncheresService;

        public CalculEncheresController(ICalculEncheresServices calculEncheresService)
        {
            _calculEncheresService = calculEncheresService;
        }

        [HttpPost("CalculPrixTotal")]
        public ActionResult<decimal> CalculPrixTotal([FromBody] VoitureDto voitureDto)
        {
            if (voitureDto == null)
            {
                return BadRequest("voiture invalid.");
            }

            var voiture = _calculEncheresService.CreationVoiture(
                            voitureDto.TypeVoiture,
                            voitureDto.PrixDeBase);

            return Ok(_calculEncheresService.CalculPrixTotal(voiture));
        }
    }
}