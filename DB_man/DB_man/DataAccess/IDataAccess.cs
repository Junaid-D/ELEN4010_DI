using DataClasses;
using NewsResponse;
using System;
using System.Collections.Generic;

namespace DataInterfaces
{
    /// <summary>
    /// Exposes CRUD operations for NewsArticle persistent stores.
    /// </summary>
    public interface IDataAccess
    {
        List<StoredArticle> Read();
        void Create(List<Article> articles);
        void Update();
        void Delete();
    }
}