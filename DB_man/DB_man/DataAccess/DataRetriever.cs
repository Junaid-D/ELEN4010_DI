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
        public DataRetriever([Named("Sql")]IDataAccess access)
        {
            access_ = access;
        }

        public void modifyAcces(IDataAccess acc)
        {
            access_ = acc;
        }

        public string getAllEntries()
        {
            var res = "";
            res = access_.Read();
            return res;
        }
    }
}
