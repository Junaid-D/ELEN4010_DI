using DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_man.DataAccess
{
    /// <summary>
    /// Highest Level class for fetching stories from persistent store.
    /// </summary>
    public class StoryRetriever
    {
        private IDataRetriever retriever;

        public StoryRetriever(IDataRetriever ret)
        {
            retriever = ret;
        }

        public List<StoredArticle> getAllStories()
        {
            return retriever.getAllEntries();
        }
    }
}
