using Kasa.Vchasno.Client;
using Kasa.Vchasno.Client.Models;
using Kasa.Vchasno.Client.Models.Responses;
using System.Text.Json;
using Xunit;

namespace Vchasno.Client.Tests
{
    public class DeserializationTests
    {
        [Fact]
        public void Should_deserialize_receipt_request_without_errors()
        {
            //example of vchasno response by tag
            const string request = "{\"info\":{\"qr\":\"https:\\/\\/kasa.vchasno.ua\\/check-viewer\\/0amfAsqY9Dgw;DT:09-12-2021T19:41:36;FR:0amfAdY9Dsgw;SUM:500;FN:400000000\",\"cancelid\":\"0amfAdY9Dgws\",\"printinfo\":{\"name\":\"TEST TEST 4\",\"shopname\":\"TEST \\\"test\\\"\",\"shopad\":\"345254363\",\"vat_code\":\"3455243631234\",\"fis_code\":\"345542363\",\"goods\":[{\"name\":\"test\",\"code\":\"11\",\"code1\":\"\",\"code2\":\"\",\"code3\":\"\",\"code_a\":\"\",\"code_aa\":[],\"cnt\":1,\"price\":600,\"cost\":600,\"disc\":60,\"taxgrp\":2,\"taxlit\":\"\u0411\",\"comment\":\"\"}],\"sum_0\":600,\"sum_receipt\":540,\"sum_disc\":60,\"sum_topay\":540,\"round\":0,\"pays\":[{\"type\":0,\"typen\":\"\u0413\u043E\u0442\u0456\u0432\u043A\u0430\",\"sum\":540,\"currency\":\"\u0433\u0440\u043D\",\"info\":\"\u041E\u0442\u0440\u0438\u043C\u0430\u043D\u043E 540.00 \u0440\u0435\u0448\u0442\u0430 0.00\",\"comment\":\"\",\"comment_up\":\"\",\"comment_down\":\"\"}],\"taxes\":[{\"gr_code\":2,\"base_sum\":540,\"tax_name\":\"\",\"tax_fname\":\"\u0411\u0435\u0437 \u041F\u0414\u0412\",\"tax_lit\":\"\u0411\",\"tax_percent\":0,\"tax_sum\":0,\"ex_name\":\"\",\"ex_percent\":0,\"ex_sum\":0}],\"fisn\":\"0amfAdY9Dgw\",\"dt\":\"09-12-2021 19:41:36\",\"qr\":\"https:\\/\\/kasa.vchasno.ua\\/check-viewer\\/0amfAsqY9Dgw;DT:09-12-2021T19:41:36;FR:0amfAdY9Dsgw;SUM:500;FN:400000000\",\"isOffline\":false,\"mac\":\"ssssss12321312313123123123\",\"fisid\":\"4000046398\",\"manuf\":\"\u0412\u0447\u0430\u0441\u043D\u043E-\u043A\u0430\u0441\u0430\",\"cashier\":\"\",\"task\":1,\"fisdoctype\":\"\u0424\u0456\u0441\u043A\u0430\u043B\u044C\u043D\u0438\u0439 \u0447\u0435\u043A\",\"comment_down\":\"\",\"comment_up\":\"\",\"safe\":0,\"docno\":\"2\",\"userdata1\":\"\",\"userdata2\":\"\",\"userdata3\":\"\"},\"dt\":\"20211209194136\",\"fisid\":\"4000022228\",\"docno\":\"2\",\"doccode\":\"0amfA3213Dgw\",\"isprint\":0,\"ispay\":0,\"cashier\":\"\",\"userdata1\":\"\",\"userdata2\":\"\",\"userdata3\":\"\",\"safe\":0,\"task\":1,\"dtype\":1,\"shift_link\":9,\"dataid\":32,\"devinfo\":\"\",\"printheader\":null},\"ver\":6,\"source\":\"payment\",\"device\":\"devie\",\"tag\":\"BABC234A-FD58-4611-AFB5-63F0591B8609\",\"type\":1,\"task\":1,\"dt\":\"20211209194136\",\"res\":0,\"res_action\":0,\"errortxt\":\"\",\"warnings\":[]}";
         
            JsonSerializerOptionsProvider jsonSerializerOptionsProvider = new JsonSerializerOptionsProvider();

            var result = JsonSerializer.Deserialize<Response<ReceiptResponse>>(request, jsonSerializerOptionsProvider.Options);

            Assert.NotNull(result);
        }
    }
}