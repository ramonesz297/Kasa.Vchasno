using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kasa.Vchasno.Client
{
    public static class VchasnoHttpClinetDependencyInjectionExtensions
    {
        public static IHttpClientBuilder AddVchasnoIntegration(this IServiceCollection services, Uri baseAddress, IConfiguration configuration)
        {
            services.AddOptions().AddOptions<VchasnoOptions>().Validate((options) =>
            {
                return !string.IsNullOrWhiteSpace(options.Token);
            });

            services.Configure<VchasnoOptions>(configuration);

            services.AddTransient<IVchasnoRequesFactory, VchasnoRequesFactory>();

            return services.AddVchasnoHttpClient(baseAddress);
        }

        public static IHttpClientBuilder AddVchasnoIntegration(this IServiceCollection services
            , Uri baseAddress
            , Action<VchasnoOptions> configureOptions)
        {
            services.AddOptions().AddOptions<VchasnoOptions>().Validate((options) =>
            {
                return !string.IsNullOrWhiteSpace(options.Token);
            });

            services.Configure(configureOptions);

            services.AddTransient<IVchasnoRequesFactory, VchasnoRequesFactory>();

            return services.AddVchasnoHttpClient(baseAddress);
        }


        public static IHttpClientBuilder AddVchasnoHttpClient(this IServiceCollection services, Uri baseAddress)
        {
            services.AddTransient<IJsonSerializerOptionsProvider, JsonSerializerOptionsProvider>();
            
            return services.AddHttpClient<IVchasnoHttpClient, VchasnoHttpClient>((client) =>
            {
                client.BaseAddress = baseAddress;
            });
        }
    }
}