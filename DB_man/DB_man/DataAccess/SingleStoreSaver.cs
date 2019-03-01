﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsResponse;
using DataInterfaces;
namespace DB_man.DataAccess
{
    class SingleStoreSaver : IResponseSaver
    {
        private IDataAccess acc_;

        public SingleStoreSaver(IDataAccess acc)
        {
            acc_ = acc;
        }

        public void saveData(List<Article> toSave)
        {
            acc_.Create(toSave);
        }
    }
}
