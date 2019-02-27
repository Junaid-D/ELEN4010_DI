using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterfaces;
using System.IO;

namespace DB_man.DataAccess
{
    public class CsvAccess : IDataAccess
    {
        private string fileName_;

        public CsvAccess(string fileName)
        {
            fileName_ = fileName;
        }
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
            var res = "";
            try
            {
                using (var reader = new StreamReader(fileName_))
                {
                    var line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        res += line+Environment.NewLine;
                    }
                }
            }
            catch (Exception e)
            {
                //logging
            }

            return res;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
