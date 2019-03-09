using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using DataInterfaces;
using DB_man.DataAccess;
using Ninject;
using DB_man.ResponseIntefaces;
using DB_man.Classification;

using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;

namespace DB_man
{
    class Program
    {

        static IKernel DefaultConfigure()
        {

            return new StandardKernel(new NewsModule(), new DataAccessModule(), new AnalyticsModule());


        }

        static void Main(string[] args)
        {
            IKernel kernel = DefaultConfigure();



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

            var analyser = kernel.Get<ICategoryFinder>();

            var listKeywords = analyser.getCategories(res.Select(article=>article.Content).ToList<string>());


            Console.WriteLine("News Powered by News API");
            Console.ReadKey();
        }
    }
}
