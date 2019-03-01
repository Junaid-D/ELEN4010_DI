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
using DB_man.ResponseIntefaces;
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

            kernel.Bind<IRequestData>().To<GoogleNews>().WhenInjectedInto<MultiNewsProvider>();
            kernel.Bind<IRequestData>().To<BBCNews>().WhenInjectedInto<MultiNewsProvider>();//conditional based on the class being injected into
            kernel.Bind<IRequestData>().To<MockRequest>().WhenInjectedInto<SingleNewsProvider>().WithConstructorArgument("fileName", @"C:\Users\USER\Dev\ELEN4010_DI\dummyResponse.txt");
            kernel.Bind<INewsProvider>().To<SingleNewsProvider>();


            //storing 
            kernel.Bind<IDataAccess>().To<SqlDBAccess>().WhenInjectedInto<MultiStoreSaver>().WithConstructorArgument("dbName", "");
            kernel.Bind<IDataAccess>().To<CsvAccess>().WhenInjectedInto<MultiStoreSaver>().WithConstructorArgument("fileName", @"C:\Users\USER\Dev\ELEN4010_DI\test.csv");
            kernel.Bind<IDataAccess>().To<SqlDBAccess>().WhenInjectedInto<SingleStoreSaver>().WithConstructorArgument("dbName", ""); ;
            kernel.Bind<IResponseSaver>().To<SingleStoreSaver>();
            /* registering - end*/
            var retriever = kernel.Get<DataRetriever>();// can bind to a method which returns concrete type instead of binding to the type
            Console.WriteLine(retriever.getAllEntries());

            retriever.modifyAcces(kernel.Get<IDataAccess>("CSV"));
            Console.WriteLine(retriever.getAllEntries());



        //    var newsprovider0 = kernel.Get<INewsProvider>("Single");
           
          
            ///

            var newsProvider1 = kernel.Get<INewsProvider>();

            var res = newsProvider1.GetArticles();
            res = newsProvider1.GetArticles();

            var responseStorer = kernel.Get<IResponseSaver>();
            responseStorer.saveData(newsProvider1.GetArticles());


            foreach (var article in res)
            {
                Console.WriteLine(article.Content);
            }



            Console.WriteLine("News Powered by News API");
            Console.ReadKey();
        }
    }
}
