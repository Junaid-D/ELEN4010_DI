using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterfaces;
using NewsResponse;

namespace DB_man.DataAccess

/// <summary>
/// Responsible for storing stories in multiple single persistent stores.
/// </summary>
{
    public class MultiStoreSaver : IResponseSaver
    {
        private List<IDataAccess> acc_;

        public MultiStoreSaver(List<IDataAccess> acc)
        {
            acc_ = acc;
        }

        public void saveData(List<Article> toSave)
        {

            foreach (IDataAccess dataStore in acc_)
                dataStore.Create(toSave);

        }
    }
}
