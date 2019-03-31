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
using DB_man.RequestClasses;
using DB_man.Classifier;

namespace DB_man
{
    class Program
    {

        static IKernel DefaultConfigure() //registration of all bindings
        {
            return new StandardKernel(new NewsModule(), new DataAccessModule(), new AnalyticsModule());
        }

        static void Main(string[] args)
        {
            IKernel kernel = DefaultConfigure();//composition root


            var newsProvider1 = kernel.Get<NewsManager>();

            Console.WriteLine("Retrieving Stories...");
            var apiRes = newsProvider1.fetchArticles();
            Console.WriteLine("Done Fetching");

            Console.WriteLine("Printing Stories...");
            foreach (var item in apiRes)
            {
                Console.WriteLine("Story fetched: {0}", item.Content);
            }

            Console.WriteLine("Done Printing");


            Console.WriteLine("Saving Stories...");
            var responseStorer = kernel.Get<StorySaver>();
            responseStorer.saveStories(apiRes);
            Console.WriteLine("Done Saving");

            Console.WriteLine("Retrieving Stories from persistent store...");

            var retriever = kernel.Get<StoryRetriever>();
            var storedStories = retriever.getAllStories();
            Console.WriteLine("Analysing For Categories");
            var analyser = kernel.Get<TextAnalyser>();
            var listKeywords = analyser.getCategories(storedStories.Select(res => res.Content).ToList());
            foreach (var item in listKeywords)
            {
                Console.WriteLine("Keyword Found: {0}", item);
            }


            Console.WriteLine("News Powered by News API.. press any key to close");
            Console.ReadKey();
        }
    }
}
