﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsResponse;

namespace DB_man.ResponseIntefaces
{
    public interface INewsProvider
    {
        List<Article> GetArticles();
    }
}
