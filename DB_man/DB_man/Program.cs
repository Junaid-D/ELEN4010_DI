using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterfaces;
using DB_man.DataAccess;
using DB_man.RequestClasses;
using DB_man.RequestInterfaces;
namespace DB_man
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataAccess d = new SqlDBAccess("");
            Console.WriteLine(d.Read());
            IDataAccess dd = new CsvAccess(@"C:\Users\USER\Dev\ELEN4010_DI\test.csv");
            Console.WriteLine(dd.Read());

            IRequestData web = new WebAPIRequest();
            var newsprovider0 = new NewsProvider(web);
            var dummyFile = @"C:\Users\USER\Dev\ELEN4010_DI\dummyResponse.txt";

            IRequestData file = new MockRequest(dummyFile);
            var newsProvider1 = new NewsProvider(file);
            var res = newsprovider0.GetArticles();
            res = newsProvider1.GetArticles();
            Console.WriteLine("Powered by News API");
            Console.ReadKey();
        }
    }
}
