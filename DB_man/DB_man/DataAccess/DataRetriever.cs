using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;
using DataInterfaces;
using Ninject;

namespace DB_man.DataAccess
{
    public class DataRetriever
    {
        private IDataAccess access_;
        public DataRetriever([Named("CSV")]IDataAccess access)//by name injection
        {
            access_ = access;
        }

        public void modifyAcces(IDataAccess acc)
        {
            access_ = acc;
        }

        public List<StoredArticle> getAllEntries()
        {
            List<StoredArticle> res = new List<StoredArticle>();
            res = access_.Read();
            return res;
        }
    }
}
