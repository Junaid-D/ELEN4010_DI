using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DB_man.RequestInterfaces;
namespace DB_man.RequestClasses
{
    class GoogleNews : IRequestData
    { 
        private string url= @"https://newsapi.org/v2/top-headlines?sources=google-news&apiKey=a9b990aa16c74b62a791bda84927c8d6";
        public string getRecent()
        {
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
