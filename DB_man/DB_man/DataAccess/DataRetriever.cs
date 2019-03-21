using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;
using DataInterfaces;

namespace DB_man.DataAccess
{
    public class SimpleDataRetriever:IDataRetriever
    {
        private IDataAccess access_;
        public SimpleDataRetriever(IDataAccess access)//by name injection
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
