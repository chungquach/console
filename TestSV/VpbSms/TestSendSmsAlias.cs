using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSV
{

    public class TestSendSmsAlias
    {
        public int totalRequestAlias;
        public void CallServiceSendAlias()
        {
            var lstRq = GetListRequestSendSms();

        }

        private List<ServiceSmsRq> GetListRequestSendSms()
        {
            List<ServiceSmsRq> lstRq = new List<ServiceSmsRq>();
            for (int i = 0; i < totalRequestAlias; i++)
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
