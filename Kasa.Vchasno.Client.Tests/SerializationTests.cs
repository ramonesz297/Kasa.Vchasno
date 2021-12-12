using Kasa.Vchasno.Client;
using Kasa.Vchasno.Client.Models;
using Kasa.Vchasno.Client.Models.Requests;
using Kasa.Vchasno.Client.Models.Responses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using RichardSzalay.MockHttp;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Vchasno.Client.Tests
{
    public class SerializationTests
    {
        private static class TestData
        {
            public static IEnumerable<object[]> GetRequests()
            {
                var mock = new Mock<IOptionsSnapshot<VchasnoOptions>>();
                mock.Setup(x => x.Value).Returns(new VchasnoOptions()
                {
                    Token = "tokem",
                    Device = "device",
                    Source = "source"
                });

                var f = new VchasnoRequesFactory(mock.Object);
                yield return new object[] { f.OpenShift() };

                yield return new object[] { f.ServiceOut(new ServiceCash(100m)) };

                yield return new object[] { f.ServiceIn(new ServiceCash(100m)) };

                yield return new object[] { f.Return(new Receipt()
                {
                    Pays = new List<ReceiptPayment>()
                    {
                        new ReceiptPayment(PaymentTypes.Cash,100),
                    },
                    CommentDown = "CommentDown",
                    CommentUp = "CommentUp",
                    Round = 0m,
                    Rows = new List<Good>()
                    {
                        new Good()
                        {
                            Code = "code",
                            Code1 = "code1",
                            Code2 = "code2",
                            Code3 = "code3",
                            CodeA = "codea",
                            CodeAA = new []{"codeaa" },
                            Comment = "comment",
                            Cost = 100,
                            Count = 1,
                            Discount = 0,
                            Name = "name",
                            Price = 100,
                            TaxGroup = DefaultVchasnoTaxGroups.Without_VAT,
                        }
                    },
                    Sum = 100,

                }) };

                yield return new object[] { f.Sale(new Receipt()
                {
                    Pays = new List<ReceiptPayment>()
                    {
                        new ReceiptPayment(PaymentTypes.Cash,100),
                    },
                    CommentDown = "CommentDown",
                    CommentUp = "CommentUp",
                    Round = 0m,
                    Rows = new List<Good>()
                    {
                        new Good()
                        {
                            Code = "code",
                            Code1 = "code1",
                            Code2 = "code2",
                            Code3 = "code3",
                            CodeA = "codea",
                            CodeAA = new []{"codeaa" },
                            Comment = "comment",
                            Cost = 100,
                            Count = 1,
                            Discount = 0,
                            Name = "name",
                            Price = 100,
                            TaxGroup = DefaultVchasnoTaxGroups.Without_VAT,
                        }
                    },
                    Sum = 100,

                }) };

                yield return new object[] { f.XReport() };

                yield return new object[] { f.ZReport() };
            }
        }

        [Theory]
        [MemberData(nameof(TestData.GetRequests), MemberType = typeof(TestData))]
        public async Task Should_serialize_without_errors(Request request)
        {
            var url = "http://localhost:3939";
            var data = new Response<BaseInfoResponse>();
            var mockHttp = new MockHttpMessageHandler();

            using var sp = new ServiceCollection()
                .AddVchasnoIntegration(new System.Uri(url), (o) =>
                {
                    o.Token = "token";
                    o.Device = "device";
                    o.Source = "service";
                }).ConfigurePrimaryHttpMessageHandler(() => mockHttp)
                .Services.BuildServiceProvider();

            var factory = sp.GetRequiredService<IVchasnoRequesFactory>();
            var client = sp.GetRequiredService<IVchasnoHttpClient>();
            var jsonOptions = sp.GetRequiredService<IJsonSerializerOptionsProvider>();

            mockHttp.When($"{url}/dm/execute").Respond("application/json", JsonSerializer.Serialize(data, jsonOptions.Options));

            var result = await client.CoreExecuteAsync<BaseInfoResponse>(request);

            Assert.NotNull(result);
        }
    }
}