using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_man.RequestInterfaces;
using System.Web;
using System.Net;

namespace DB_man.RequestClasses
{
    public class BBCNews : IRequestData
    {
        private string endpoint = "https://newsapi.org/v2/top-headlines?sources=bbc-news";
        //https://newsapi.org/v2/top-headlines?sources=bbc-news&apiKey=a9b990aa16c74b62a791bda84927c8d6
        public string getRecent()
        {
            var url = endpoint + "&apiKey=" + System.Configuration.ConfigurationManager.AppSettings["NewsKey"].ToString();
            var json = "";
            try
            {
                json = new WebClient().DownloadString(url);
            }
            catch (Exception e)
            {

            }
            return json;
        }
    }
}
