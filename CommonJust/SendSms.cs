using Application;
using IPE.SmsIrClient;
using IPE.SmsIrClient.Models.Results;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace CommonJust
{
    public class SendSms : ISendSms<SmsIrResult<SendResult>>
    {

        public async Task<SmsIrResult<SendResult>> DoSmS(long LineNumber, string MessageText, string[] Mobile, int SendDate)
        {
            //SmsIr smsIr = new SmsIr("YOUR API KEY");
            SmsIr smsIr = new SmsIr("YOUR API KEY");

            var bulkSendResult = await smsIr.BulkSendAsync(LineNumber, MessageText
                , Mobile,
                SendDate

                );

            return bulkSendResult;


        }

     

    }
}
