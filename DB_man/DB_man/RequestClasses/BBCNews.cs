﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_man.RequestInterfaces;
using System.Web;
using System.Net;

namespace DB_man.RequestClasses
{
    /// <summary>
    /// Obtains news JSON using BBCNews endpoint.
    /// </summary>
    public class BBCNews : IRequestData
    {
        private string endpoint = "https://newsapi.org/v2/top-headlines?sources=bbc-news";
        public string getRecent()
        {
            var url = endpoint + "&apiKey=" + System.Configuration.ConfigurationManager.AppSettings["NewsKey"].ToString();//fetch key from config
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
