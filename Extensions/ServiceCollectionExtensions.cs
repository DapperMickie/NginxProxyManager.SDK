using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NginxProxyManager.SDK.Configuration;
using NginxProxyManager.SDK.Services;
using NginxProxyManager.SDK.Services.Interfaces;
using NginxProxyManager.SDK.Client;

namespace NginxProxyManager.SDK.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds Nginx Proxy Manager SDK services to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The NPM configuration.</param>
        /// <returns>The service collection for chaining.</returns>
        public static IServiceCollection AddNginxProxyManager(this IServiceCollection services, NPMConfiguration configuration)
        {
            // Register configuration
            services.AddSingleton(configuration);

            // Register base NPM service
            services.AddHttpClient<NPMServiceBase>(client =>
            {
                client.BaseAddress = new Uri(configuration.BaseUrl);
                client.Timeout = TimeSpan.FromSeconds(configuration.TimeoutSeconds);
            });

            // Register all other services
            services.AddScoped<IAccessListService, AccessListService>();
            services.AddScoped<ICertificateService, CertificateService>();
            services.AddScoped<IProxyHostService, ProxyHostService>();
            services.AddScoped<IRedirectionService, RedirectionService>();
            services.AddScoped<IStreamService, StreamService>();
            services.AddScoped<IAuditLogService, AuditLogService>();
            services.AddScoped<IServerErrorService, ServerErrorService>();

            services.AddScoped(sp => 
                new NginxProxyManagerClient(configuration.BaseUrl, AuthenticationCredentials.FromCredentials(configuration.Email, configuration.Password))
            );

            return services;
        }

        /// <summary>
        /// Adds Nginx Proxy Manager SDK services to the service collection using configuration from appsettings.json.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configurationSection">The name of the configuration section in appsettings.json (default: "NginxProxyManager")</param>
        /// <returns>The service collection for chaining.</returns>
        public static IServiceCollection AddNginxProxyManager(this IServiceCollection services, string configurationSection = "NginxProxyManager")
        {
            services.AddOptions<NPMConfiguration>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection(configurationSection).Bind(settings);
                });

            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IOptions<NPMConfiguration>>().Value;

            return AddNginxProxyManager(services, configuration);
        }
    }
} 