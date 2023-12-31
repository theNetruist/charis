using AeonTek.Charis.API.Data.ValueObjects;
using AeonTek.Charis.API.Logic.Interfaces;

namespace AeonTek.Charis.API.Logic.Concretes
{
    internal class WaiverLogic(IOrganizationLogic _orgLogic) : IWaiverLogic
    {
        public async Task<WaiverTemplate> GetCurrentWaiverTemplate(string orgId)
        {
            return (await _orgLogic.GetOrganization(orgId)).GetCurrentTemplate();
        }

        public async Task<List<WaiverTemplate>> GetWaiverTemplates(string orgId)
        {
            return (await _orgLogic.GetOrganization(orgId)).GetAllTemplates();
        }

        public async Task<WaiverTemplate> UpdateCurrentWaiverTemplate(string orgId, string markDown)
        {
            var org = await _orgLogic.GetOrganization(orgId);
            var newWaiver = org.AddTemplate(markDown);
            await _orgLogic.SaveChanges();
            return newWaiver;
        }
    }
}
