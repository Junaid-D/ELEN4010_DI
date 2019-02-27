using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterfaces;
using DbAccess;
namespace DB_man
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataAccess d = new SqlDBAccess("");
            Console.WriteLine(d.Read());
            Console.ReadKey();
        }
    }
}
