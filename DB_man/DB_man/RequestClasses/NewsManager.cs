using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_man.ResponseIntefaces;
using NewsResponse;
using Ninject;

namespace DB_man.RequestClasses
{
    /// <summary>
    /// Highest level class for fetching stories.
    /// </summary>
    public class NewsManager
    {
        private INewsProvider newsProvider;
        public NewsManager([Named("MultiNews")] INewsProvider prov)
        {
            newsProvider = prov;
        }

        public List<Article> fetchArticles()
        {
            return newsProvider.GetArticles();
        }

    }
}
