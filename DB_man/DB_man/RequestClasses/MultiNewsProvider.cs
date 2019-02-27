﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_man.ResponseIntefaces;
using NewsResponse;
using DB_man.RequestInterfaces;
namespace DB_man.RequestClasses
{
    public class MultiNewsProvider : INewsProvider
    {
        private List<IRequestData> requesters_;

        public MultiNewsProvider(List<IRequestData> req)
        {
            requesters_ = req;
        }

        public List<Article> GetArticles()
        {
            List<Article> res = new List<Article>();
            foreach(IRequestData reqData in requesters_)
            {
                var jsonString = reqData.getRecent();
                var deserialised = NewsData.FromJson(jsonString);
                res.AddRange(deserialised.Articles);

            }
            return res;
        }
    }
}
