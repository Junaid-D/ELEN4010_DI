using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsResponse;
using DataInterfaces;
namespace DB_man.DataAccess
{
    class SingleStoreSaver : IResponseSaver
    {
        private IDataAccess acc_;
        
        public SingleStoreSaver(IDataAccess acc)
        {
            acc_ = acc;
        }

        public void saveData(List<NewsData> toSave)
        {
            foreach (var item in toSave)
            {
                acc_.Create();
            }
        }
    }
}
