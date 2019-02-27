using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterfaces;
using DB_man.DataAccess;
using DB_man.RequestClasses;
using DB_man.RequestInterfaces;
using Ninject;

namespace DB_man
{
    class Program
    {
        static void Main(string[] args)
        {
            /*registering**/
            IKernel kernel = new StandardKernel();
            kernel.Bind<IDataAccess>().To<SqlDBAccess>().Named("Sql").WithConstructorArgument("dbName", ""); // bind with argument to instantiate concrete
            kernel.Bind<IDataAccess>().To<CsvAccess>().Named("CSV").WithConstructorArgument("fileName", @"C:\Users\USER\Dev\ELEN4010_DI\test.csv");


             /* registering - end*/
            var retriever = kernel.Get<DataRetriever>();// can bind to a method which returns concrete type instead of binding to the type
            Console.WriteLine(retriever.getAllEntries());

            retriever.modifyAcces(kernel.Get<IDataAccess>("CSV"));
            Console.WriteLine(retriever.getAllEntries());


            IRequestData web = new WebAPIRequest();
            var newsprovider0 = new NewsProvider(web);
            var dummyFile = @"C:\Users\USER\Dev\ELEN4010_DI\dummyResponse.txt";

            IRequestData file = new MockRequest(dummyFile);
            var newsProvider1 = new NewsProvider(file);
            var res = newsprovider0.GetArticles();
            res = newsProvider1.GetArticles();
            Console.WriteLine("News Powered by News API");
            Console.ReadKey();
        }
    }
}
