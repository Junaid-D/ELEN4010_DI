using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;
using DataInterfaces;
using NewsResponse;

namespace DB_man.DataAccess
{
    /// <summary>
    /// Implemets CRUD operations for mocking purposes. Currently not implemented and unused.
    /// </summary>
    class MockAccess : IDataAccess
    {

        public void Create(List<Article> articles)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public List<StoredArticle> Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
