using JwtTokenCreator.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace JwtTokenCreator
{
    public static partial class RegisterContractMappings
    {
        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.
                RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            
            services.AddTransient<IJWTTOKEN, JWTTokenService>();
            services.AddHttpContextAccessor();
        }
    }
}
