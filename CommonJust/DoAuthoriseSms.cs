using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CommonJust
{
    public  class DoAuthoriseSms
    {

        public async Task AuthoriseSmsAsync()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-api-key", "5AjUpQILp9t7D2UdaoaJxxxxJdXX0c1dAo456usriKbgyYXqblciFvTm5NLM2346Ipcs");
            VerifySendModel model = new VerifySendModel()
            {
                Mobile = "9120000000",
                TemplateId = 123456,
                Parameters = new VerifySendParameterModel[]
                {
                    new VerifySendParameterModel { Name = "CODE", Value = "1234" },
                    new VerifySendParameterModel  { Name = "CODE2", Value = "9000" }
                }
            };

            string payload = JsonSerializer.Serialize(model);
            StringContent stringContent = new(payload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("https://api.sms.ir/v1/send/verify", stringContent);
        }


    }

    public class VerifySendParameterModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class VerifySendModel
    {
        public string Mobile { get; set; }
        public int TemplateId { get; set; }
        public VerifySendParameterModel[] Parameters { get; set; }

    }
}