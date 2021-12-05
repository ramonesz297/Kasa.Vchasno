using Kasa.Vchasno.Client;
using Kasa.Vchasno.Client.Models;
using Kasa.Vchasno.Client.Models.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RichardSzalay.MockHttp;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Vchasno.Client.Tests
{
    public class VchasnoDependencyInjectionTests
    {
        [Fact]
        public async Task Should_send_request_to_provided_base_address()
        {
            var url = "http://localhost:3939";

            var data = new Response<BaseInfoResponse>();

            var mockHttp = new MockHttpMessageHandler();

            var serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddVchasnoHttpClient(new System.Uri(url))
                .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

            using var sp = serviceDescriptors.BuildServiceProvider();

            using var scope = sp.CreateScope();

            var jsonOptions = scope.ServiceProvider.GetRequiredService<IJsonSerializerOptionsProvider>();

            mockHttp.When($"{url}/dm/execute").Respond("application/json", JsonSerializer.Serialize(data, jsonOptions.Options));

            var client = scope.ServiceProvider.GetRequiredService<IVchasnoHttpClient>();

            var response = await client.ExecuteAsync<BaseInfoResponse>(new Request("test"));

            Assert.NotNull(response);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_throw_error_when_options_not_configured_using_configurations_section(string token)
        {
            var configurationRoot = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>()
                {
                     {"Token", token }
                }).Build();

            var serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddVchasnoIntegration(new System.Uri("http://localhost:3939"), configurationRoot);

            using var sp = serviceDescriptors.BuildServiceProvider();

            Assert.Throws<OptionsValidationException>(() => sp.GetRequiredService<IOptions<VchasnoOptions>>().Value);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_throw_error_when_options_not_configured_using_configurations_action(string token)
        {
            var serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddVchasnoIntegration(new System.Uri("http://localhost:3939"), (o) =>
            {
                o.Token = token;
            });

            using var sp = serviceDescriptors.BuildServiceProvider();

            Assert.Throws<OptionsValidationException>(() => sp.GetRequiredService<IOptions<VchasnoOptions>>().Value);
        }

        [Fact]
        public void Should_return_service_without_errors_when_options_configured_using_configurations_section()
        {
            var configurationRoot = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>()
                {
                    {"Token","token" }
                }).Build();

            var serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddVchasnoIntegration(new System.Uri("http://localhost:3939"), configurationRoot);

            using var sp = serviceDescriptors.BuildServiceProvider();

            Assert.NotNull(sp.GetRequiredService<IOptions<VchasnoOptions>>().Value);
        }

        [Fact]
        public void Should_return_service_without_errors_when_options_configured_using_configurations_action()
        {
            var serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddVchasnoIntegration(new System.Uri("http://localhost:3939"), (o) =>
            {
                o.Token = "token";
            });

            using var sp = serviceDescriptors.BuildServiceProvider();

            Assert.NotNull(sp.GetRequiredService<IOptions<VchasnoOptions>>().Value);
        }

        [Fact]
        public void Should_update_options_on_option_source_change()
        {
            var serviceDescriptors = new ServiceCollection();
            var source = new Dictionary<string, string>()
              {
                    {"Token","token" }
              };

            var configurationRoot = new ConfigurationBuilder()
              .AddInMemoryCollection(source).Build();

            serviceDescriptors.AddVchasnoIntegration(new System.Uri("http://localhost:3939"), configurationRoot);

            using var sp = serviceDescriptors.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var o = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<VchasnoOptions>>().Value;
                Assert.Equal("token", o.Token);
            }

            configurationRoot.Providers.ElementAt(0).Set("Token", "token2");
            configurationRoot.Reload();

            using (var scope = sp.CreateScope())
            {
                var o = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<VchasnoOptions>>().Value;
                Assert.Equal("token2", o.Token);
            }
        }
    }
}