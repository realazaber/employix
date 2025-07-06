using Employix.Domain.Models;
using Employix.Domain.Models.Entities;
using Employix.Infrastructure.Data;
using Employix.Infrastructure.Services;
using Employix.Presentation.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Employix.Presentation.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {

            // Add services to the container.
            services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            services.Configure<EmailSettings>(options =>
            {
                options.Sender = Environment.GetEnvironmentVariable("SMTP_EMAIL_ADDRESS");
                options.Password = Environment.GetEnvironmentVariable("SMTP_PASSWORD");
                options.Provider = Environment.GetEnvironmentVariable("SMTP_CLIENT_PROVIDER");
                options.MyEmail = Environment.GetEnvironmentVariable("SMTP_MY_EMAIL");
                options.Port = int.TryParse(Environment.GetEnvironmentVariable("SMTP_PORT"), out var port) ? port : 25;
            });


            services.AddSingleton<IEmailSender<User>, MailSender>();
            services.AddCascadingAuthenticationState();
            services.AddScoped<IdentityUserAccessor>();
            services.AddScoped<IdentityRedirectManager>();
            services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
                .AddIdentityCookies();

            services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddSignInManager()
                    .AddDefaultTokenProviders();


            return services;
        }
    }
}
