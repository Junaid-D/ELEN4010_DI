using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterfaces;
using DB_man.DataAccess;
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
            Console.ReadKey();
        }
    }
}
