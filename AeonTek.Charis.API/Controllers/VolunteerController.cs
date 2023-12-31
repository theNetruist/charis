using AeonTek.Charis.API.Data.ValueObjects;
using AeonTek.Charis.API.Extensions;
using AeonTek.Charis.API.Logic;
using AeonTek.Charis.API.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace AeonTek.Charis.API.Controllers
{
    [Route("api/org/{orgId}/volunteer")]
    [ApiController]
    public class VolunteerController(ILogger<VolunteerController> _logger, IVolunteerLogic _volunteerLogic) : ControllerBase
    {

        [HttpGet()]
        [SwaggerOperation(Summary = "Retrieves all volunteers")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(List<VolunteerDto>), ["application/json"])]
        public async Task<IActionResult> GetVolunteers(string orgId)
        {
            var ret = await _volunteerLogic.GetVolunteers(orgId);
            return Ok(ret.ToDto());
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieves volunteer by ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(VolunteerDto), ["application/json"])]
        public async Task<IActionResult> GetVolunteer(string orgId, Guid id)
        {
            var ret = await _volunteerLogic.GetVolunteer(orgId, id);
            return Ok(ret.ToDto());
        }

        [HttpGet("{firstName=firstName}/{lastName=lastName}")]
        [SwaggerOperation(Summary = "Retrieves volunteers by name")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(VolunteerDto), ["application/json"])]
        public async Task<IActionResult> GetVolunteersByName(string orgId, string lastName, string? firstName = null)
        {
            var ret = await _volunteerLogic.GetVolunteersByName(orgId, lastName, firstName);
            return Ok(ret.ToDto());
        }

        [HttpPost()]
        [SwaggerOperation(Summary = "Adds a new volunteer")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(VolunteerDto), ["application/json"])]
        public async Task<IActionResult> AddVolunteer(string orgId, [FromBody] NameDto name)
        {
            var ret = await _volunteerLogic.AddVolunteer(orgId, name.LastName, name.FirstName);
            return Ok(ret.ToDto());
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes volunteer")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(VolunteerDto), ["application/json"])]
        public async Task<IActionResult> RemoveVolunteers(string orgId, Guid id)
        {
            var ret = await _volunteerLogic.RemoveVolunteer(orgId, id);
            return Ok(ret.ToDto());
        }

        [HttpPost("waiver")]
        [SwaggerOperation(Summary = "Records the date/time that the waiver was signed, and the version of the waiver that was signed")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(VolunteerDto), ["application/json"])]
        public async Task<IActionResult> SignWaiver(string orgId, [FromBody] SignWaiverDto signWaiver)
        {
            var ret = await _volunteerLogic.SignWaiver(orgId, signWaiver.VolunteerId, signWaiver.WaiverId);
            return Ok(ret.ToDto());
        }

        [HttpPost("{volunteerId}/contacts")]
        [SwaggerOperation(Summary = "Adds contact information for a volunteer")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(Contact), ["application/json"])]
        public async Task<IActionResult> AddContactToVolunteer(string orgId, Guid volunteerId, [FromBody] Contact contact)
        {
            var ret = await _volunteerLogic.AddContactToVolunteer(orgId, volunteerId, contact);
            return Ok(ret);
        }
    }
}
