using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kasa.Vchasno.Client
{
    public static class VchasnoHttpClinetDependencyInjectionExtensions
    {
        public static IHttpClientBuilder AddVchasnoIntegration(this IServiceCollection services, Uri baseAddress, IConfiguration configuration)
        {
            services.Configure<VchasnoOptions>(configuration);
            return services.AddVchasnoIntegration(baseAddress);
        }

        public static IHttpClientBuilder AddVchasnoIntegration(this IServiceCollection services, Uri baseAddress, Action<VchasnoOptions> configureOptions)
        {
            services.Configure(configureOptions);
            return services.AddVchasnoIntegration(baseAddress);
        }

        public static IHttpClientBuilder AddVchasnoIntegration<TRequestFactory, TJsonSerializer>(this IServiceCollection services,
                                                                                                 Uri baseAddress,
                                                                                                 IConfiguration configuration)
             where TRequestFactory : class, IVchasnoRequesFactory
             where TJsonSerializer : class, IJsonSerializerOptionsProvider
        {
            services.Configure<VchasnoOptions>(configuration);
            return services.AddVchasnoIntegration<TRequestFactory, TJsonSerializer>(baseAddress);
        }

        public static IHttpClientBuilder AddVchasnoIntegration<TRequestFactory, TJsonSerializer>(this IServiceCollection services,
                                                                                                 Uri baseAddress,
                                                                                                 Action<VchasnoOptions> configureOptions)
             where TRequestFactory : class, IVchasnoRequesFactory
             where TJsonSerializer : class, IJsonSerializerOptionsProvider
        {
            services.Configure(configureOptions);
            return services.AddVchasnoIntegration<TRequestFactory, TJsonSerializer>(baseAddress);
        }


        public static IHttpClientBuilder AddVchasnoIntegration(this IServiceCollection services, Uri baseAddress)
        {
            return services.AddVchasnoIntegration<VchasnoRequesFactory, JsonSerializerOptionsProvider>(baseAddress);
        }

        public static IHttpClientBuilder AddVchasnoIntegration<TRequestFactory, TJsonSerializer>(this IServiceCollection services, Uri baseAddress)
            where TRequestFactory : class, IVchasnoRequesFactory
            where TJsonSerializer : class, IJsonSerializerOptionsProvider
        {
            services.AddOptions().AddOptions<VchasnoOptions>().Validate((options) =>
            {
                return !string.IsNullOrWhiteSpace(options.Token) && !string.IsNullOrWhiteSpace(options.Device);
            });

            services.AddTransient<IVchasnoRequesFactory, TRequestFactory>();

            return services.AddVchasnoHttpClient<TJsonSerializer>(baseAddress);
        }

        private static IHttpClientBuilder AddVchasnoHttpClient<TJsonSerializer>(this IServiceCollection services, Uri baseAddress)
            where TJsonSerializer : class, IJsonSerializerOptionsProvider
        {
            services.AddTransient<IJsonSerializerOptionsProvider, TJsonSerializer>();

            return services.AddHttpClient<IVchasnoHttpClient, VchasnoHttpClient>((client) =>
            {
                client.BaseAddress = baseAddress;
            });
        }
    }
}