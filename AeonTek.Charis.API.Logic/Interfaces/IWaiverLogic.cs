using AeonTek.Charis.API.Data.ValueObjects;

namespace AeonTek.Charis.API.Logic.Interfaces
{
    public interface IWaiverLogic
    {
        Task<WaiverTemplate> GetCurrentWaiverTemplate(string orgId);
        Task<List<WaiverTemplate>> GetWaiverTemplates(string orgId);
        Task<WaiverTemplate> UpdateCurrentWaiverTemplate(string orgId, string markDown);
    }
}
