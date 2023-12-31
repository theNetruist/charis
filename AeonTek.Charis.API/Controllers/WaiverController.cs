using AeonTek.Charis.API.Data.ValueObjects;
using AeonTek.Charis.API.Extensions;
using AeonTek.Charis.API.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AeonTek.Charis.API.Controllers
{
    [Route("api/{orgId}/waiver")]
    [ApiController]
    public class WaiverController(ILogger<WaiverController> _logger, IWaiverLogic _waiverLogic) : ControllerBase
    {
        [HttpGet()]
        [SwaggerOperation(Summary = "Gets the current version of the waiver")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(WaiverTemplate), ["application/json"])]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Waiver not found", typeof(string), ["application/json"])]
        public async Task<IActionResult> GetCurrentWaiver(string orgId)
        {
            try
            {
                var ret = await _waiverLogic.GetCurrentWaiverTemplate(orgId);
                return Ok(ret.ToDto());
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost()]
        [SwaggerOperation(Summary = "Updates the waiver to the provided text.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(WaiverTemplate), ["application/json"])]
        public async Task<IActionResult> UpdateCurrentWaiver(string orgId, [SwaggerRequestBody("The updated waiver text. Accepts MarkDown formatting.")][FromBody] string waiver)
        {
            var ret = await _waiverLogic.UpdateCurrentWaiverTemplate(orgId, waiver);
            return Ok(ret.ToDto());
        }
    }
}
