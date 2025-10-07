using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ISendSms<T> where T : class
    {
        //  SmsIr smsIr = new SmsIr("YOUR API KEY");

            Task<T> DoSmS(long LineNumber, string MessageText, string[] Mobile, int SendDate);
       
            
            
    }
}
