using DataClasses;
using System.Collections.Generic;

namespace DB_man.DataAccess
{
    /// <summary>
    /// Responsible for retrieving stories from persistent store.
    /// </summary>
    public interface IDataRetriever
    {
        List<StoredArticle> getAllEntries();
    }
}