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


            var newsProvider1 = kernel.Get<INewsProvider>();

            Console.WriteLine("Retrieving Stories...");
            var apiRes = newsProvider1.GetArticles();
            Console.WriteLine("Done Fetching");

            Console.WriteLine("Saving Stories...");
            var responseStorer = kernel.Get<IResponseSaver>();
            responseStorer.saveData(apiRes);
            Console.WriteLine("Done Saving");

            Console.WriteLine("Retrieving Stories from persistent store...");

            var retriever = kernel.Get<DataRetriever>();
            var storedStories = retriever.getAllEntries();
            Console.WriteLine("Analysing For Categories");
            var analyser = kernel.Get<ICategoryFinder>();
            var listKeywords = analyser.getCategories(storedStories.Select(res=> res.Content).ToList());
            foreach(var item in listKeywords)
            {
                Console.WriteLine("Keyword Found: {0}", item);
            }


            Console.WriteLine("News Powered by News API");
            Console.ReadKey();
        }
    }
}
