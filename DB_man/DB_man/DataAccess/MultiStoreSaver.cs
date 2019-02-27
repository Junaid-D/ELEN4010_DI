using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterfaces;
using NewsResponse;

namespace DB_man.DataAccess
{
    public class MultiStoreSaver : IResponseSaver
    {
        private List<IDataAccess> acc_;

        public MultiStoreSaver(List<IDataAccess> acc)
        {
            acc_ = acc;
        }

        public void saveData(List<NewsData> toSave)
        {
            foreach (var item in toSave)
            {
                foreach (IDataAccess dataStore in acc_)
                    dataStore.Create();
            }
        }
    }
}
