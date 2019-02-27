using System;
using DataInterfaces;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DbAccess
{
	public class SqlDBAccess: IDataAccess
	{
        private string dbName_;
        private OleDbConnection conn=null;
        public SqlDBAccess(string dbName)
        {
            dbName_ = dbName;
        }

        public string Read()
        {
            var res="";
            using (conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\USER\Dev\ELEN4010_DI\testDB.accdb"))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("Select * FROM tbResponses", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        foreach (var item in reader)
                        {
                            res += item.ToString() + ',';
                        }
                        res += Environment.NewLine;
                    }

                }

            }
            return res;
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
