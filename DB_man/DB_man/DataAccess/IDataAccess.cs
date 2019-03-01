using NewsResponse;
using System;
using System.Collections.Generic;

namespace DataInterfaces
{
    public interface IDataAccess
    {

        string Read();
        void Create(List<Article> articles);
        void Update();
        void Delete();


    }
}