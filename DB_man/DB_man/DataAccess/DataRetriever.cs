using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterfaces;
using Ninject;

namespace DB_man.DataAccess
{
    public class DataRetriever
    {
        private IDataAccess access_;
        public DataRetriever([Named("Sql")]IDataAccess access)//by name injection
        {
            access_ = access;
        }

        public void modifyAcces(IDataAccess acc)
        {
            access_ = acc;
        }

        public List<string> getAllEntries()
        {
            List<string> res = new List<string>();
            res = access_.Read().Split(',').ToList();
            return res;
        }
    }
}
