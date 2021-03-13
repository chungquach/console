using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSV
{
    public class TestSendSms8x49
    {
        public int totalRequest8x49;

        public void CallServiceSend8149()
        {
            var lstRq = GetListRequestSendSms();
        }


        private List<ServiceSmsRq> GetListRequestSendSms()
        {
            List<ServiceSmsRq> lstRq = new List<ServiceSmsRq>();
            for (int i = 0; i < totalRequest8x49; i++)
            {
                var rq = new ServiceSmsRq
                {
                    DupllicateId = Guid.NewGuid().ToString(),
                    SenderId = "8x49",
                    Destination = "0982511597"
                };
                lstRq.Add(rq);
            }
            return lstRq;
        }
    }
}
