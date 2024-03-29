﻿using DB_man.RequestInterfaces;
using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DB_man
{
    /// <summary>
    /// This class makes use of ninject interceptor functionality to log excepts and select function calls.
    /// </summary>
    public class ExceptionInterceptor : IInterceptor
    {
        public ExceptionInterceptor()
        {

        }

        public void Intercept(IInvocation invocation)
        {
            var filePath = System.Configuration.ConfigurationManager.AppSettings["DefLog"];

            if (invocation.Request.Target.GetType().GetInterfaces().Contains(typeof(IRequestData)))
            {
                using (StreamWriter writer = File.AppendText(filePath))//log API requests
                {

                    writer.WriteLine("Api Request made in {0} with API Key {1}, at Time: {2}", invocation.Request.Target.GetType().ToString(),
                        System.Configuration.ConfigurationManager.AppSettings["NewsKey"],
                        DateTime.Now.ToString());
                }
            }

            try
            {   //call function body
                invocation.Proceed();
            }
            catch (Exception e)
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    //log exceptions
                    writer.WriteLine("###Exception caught in {0}", invocation.Request.Target.GetType().ToString());
                    writer.WriteLine("Exception detail: {0}", e.ToString());
                    writer.WriteLine("Callstack detail: {0}", e.StackTrace.ToString());
                    writer.WriteLine("Time: {0}", DateTime.Now.ToString());
                }
            }
        }
    }
}
