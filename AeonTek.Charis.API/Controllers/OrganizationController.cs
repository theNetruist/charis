using AeonTek.Charis.API.Extensions;
using AeonTek.Charis.API.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AeonTek.Charis.API.Controllers
{
    [Route("api/org")]
    [ApiController]
    public class OrganizationController(IOrganizationLogic _organizationLogic) : ControllerBase
    {
        [HttpPost()]
        public async Task<IActionResult> AddOrganization([FromBody] string name)
        {
            return Ok((await _organizationLogic.AddOrganization(name)).ToDto());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganization(string id)
        {
            return Ok((await _organizationLogic.GetOrganization(id)).ToDto());
        }

        [HttpGet()]
        public async Task<IActionResult> GetOrganizations()
        {
            return Ok((await _organizationLogic.GetOrganizations()).ToDto());
        }
    }
}
