﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSV
{
    public class TestProcess
    {
        public int totalTaskSendAlias, totalTaskSend8149,totalRequestAlias, totalRequest8x49;
        public void Run()
        {
            List<Task> lstTask = new List<Task>();

            if (totalTaskSendAlias > 0)
            {
                for (int i = 0; i < totalTaskSendAlias; i++)
                {
                    TestSendSmsAlias obj = new TestSendSmsAlias();
                    obj.totalRequestAlias = this.totalRequestAlias;
                    lstTask.Add(Task.Factory.StartNew(obj.CallServiceSendAlias));
                }
            }

            if (totalTaskSend8149 > 0)
            {
                for (int i = 0; i < totalTaskSend8149; i++)
                {
                    TestSendSms8x49 obj = new TestSendSms8x49();
                    obj.totalRequest8x49 = this.totalRequest8x49;

                    lstTask.Add(Task.Factory.StartNew(obj.CallServiceSend8149));
                }
            }
            Task.WaitAll(lstTask.ToArray());
        }
    }
}
