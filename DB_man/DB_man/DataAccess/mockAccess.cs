using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterfaces;
namespace DB_man.DataAccess
{
    class mockAccess : IDataAccess
    {
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public string Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
