using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsResponse;

namespace DB_man.DataAccess
{
    /// <summary>
    /// Responsible for storing stories in persistent storage.
    /// </summary>
    interface IResponseSaver
    {
        void saveData(List<Article> toSave);
    }
}
