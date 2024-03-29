﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_man.RequestInterfaces;
using System.IO;
namespace DB_man.RequestClasses
{
    /// <summary>
    /// Obtains news JSON using static text file. For offline use or testing.
    /// </summary>
    class MockRequest : IRequestData
    {
        private string file_;
        public MockRequest()
        {
            file_ = System.Configuration.ConfigurationManager.ConnectionStrings["MockResponse"].ConnectionString;
        }

        public string getRecent()
        {
            var res = "";
            res = File.ReadAllText(file_);
            return res;
        }
    }
}
