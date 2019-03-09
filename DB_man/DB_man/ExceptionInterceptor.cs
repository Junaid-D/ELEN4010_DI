using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_man
{
    public class ExceptionInterceptor : IInterceptor
    {
        public ExceptionInterceptor()
        {
           
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("caught an exception");
            }
        }
    }
}
