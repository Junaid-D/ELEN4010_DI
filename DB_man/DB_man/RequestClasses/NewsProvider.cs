using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_man.RequestInterfaces;
using NewsResponse;
namespace DB_man.RequestClasses
{

    public class NewsProvider
    {
        private IRequestData requester_;

        public NewsProvider(IRequestData data)
        {
            requester_ = data;
        }

        public List<Article> GetArticles()
        {
            var res = new List<Article>();

            var newsResponse = requester_.getRecent();
            res = NewsData.FromJson(newsResponse).Articles;

            return res;
        }
    }
}
