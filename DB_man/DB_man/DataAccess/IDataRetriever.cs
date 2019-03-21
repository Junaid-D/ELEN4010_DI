using DataClasses;
using System.Collections.Generic;

namespace DB_man.DataAccess
{
    public interface IDataRetriever
    {
        List<StoredArticle> getAllEntries();
    }
}