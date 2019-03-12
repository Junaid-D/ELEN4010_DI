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
        private string endpoint= @"https://newsapi.org/v2/top-headlines?sources=google-news";
        public string getRecent()
        {
            var json = "";
            var url = endpoint + "&apiKey=" + System.Configuration.ConfigurationManager.AppSettings["NewsKey"].ToString();
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
