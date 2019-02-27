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
    public class WebAPIRequest : IRequestData
    {
        private string key = "a9b990aa16c74b62a791bda84927c8d6";
        private string endpoint = "https://newsapi.org/v2/top-headlines?";
        private string country = "country=us&";
        public string getRecent()
        {
            var url = endpoint + country + "apiKey=" + key;
            var json = new WebClient().DownloadString(url);
            return json;
        }
    }
}
