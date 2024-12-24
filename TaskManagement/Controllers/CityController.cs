using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.CityFeatures.Command;
using TaskManagement.Application.Features.CityFeatures.Queries;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region "commands"
        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(command);

            if (response.Data > 0)
            {
                return CreatedAtAction(nameof(GetCityByCode), new { code = command.Code }, response);
            }

            return BadRequest(new { Message = "Unable to create the city." });
        }
        #endregion

        #region " queries "
        [HttpGet("{code}")]
        public async Task<IActionResult> GetCityByCode(string code)
        {
            var query = new GetCityQuery { Code = code };
            var response = await _mediator.Send(query);

            if (response.Data == null)
            {
                return NotFound(new { Message = "City not found." });
            }

            return Ok(response);
        }
        #endregion
    }
}
