using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using SFA.DAS.CourseDelivery.Api.Infrastructure;
using SFA.DAS.CourseDelivery.Domain.Configuration;
using SFA.DAS.CourseDelivery.Infrastructure.Configuration;

namespace SFA.DAS.CourseDelivery.Api.AppStart
{
    public static class AddAuthenticationExtension
    {
        public static void AddAuthentication(this IServiceCollection services, AzureActiveDirectoryConfiguration config)
        {
            
            services.AddAuthorization(o =>
            {
                o.AddPolicy(PolicyNames.Default, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole(RoleNames.Default);
                });
                o.AddPolicy(PolicyNames.DataLoad, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole(RoleNames.DataLoad);
                });
            });
                
            services.AddAuthentication(auth => { auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(auth =>
                {
                    auth.Authority =
                        $"https://login.microsoftonline.com/{config.Tenant}";
                    auth.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidAudiences = new List<string>
                        {
                            config.Identifier
                        }
                    };
                });
            services.AddSingleton<IClaimsTransformation, AzureAdScopeClaimTransformation>();
        }
    }
    
}