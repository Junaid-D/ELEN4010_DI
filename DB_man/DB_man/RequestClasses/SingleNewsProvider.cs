using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_man.RequestInterfaces;
using NewsResponse;
using DB_man.ResponseIntefaces;
namespace DB_man.RequestClasses
{

    public class SingleNewsProvider : INewsProvider
    {
        private IRequestData requester_;

        public SingleNewsProvider(IRequestData data)
        {
            requester_ = data;
        }

        public List<Article> GetArticles()
        {
            var res = new List<Article>();

            var newsResponse = requester_.getRecent();
            try
            {
                res = NewsData.FromJson(newsResponse).Articles;
            }
            catch (Exception e)
            {

            }
            return res;
        }
    }
}
