using AeonTek.Charis.API.Logic.Concretes;
using AeonTek.Charis.API.Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AeonTek.Charis.API.Logic
{
    public static class Registration
    {
        public static IServiceCollection AddCharisLogic(this IServiceCollection services)
        {
            services.AddTransient<IVolunteerLogic, VolunteerLogic>();
            services.AddTransient<IWaiverLogic, WaiverLogic>();
            services.AddTransient<IOrganizationLogic, OrganizationLogic>();
            return services;
        }
    }
}
