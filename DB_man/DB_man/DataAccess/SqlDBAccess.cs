using System;
using DataInterfaces;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using NewsResponse;
using System.Collections.Generic;
namespace DB_man.DataAccess
{
    public class SqlDBAccess : IDataAccess
    {
        private OleDbConnection conn = null;
        public SqlDBAccess()
        {
        }

        public string Read()
        {
            var res = "";
            using (conn = new OleDbConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString ))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {

                }
                OleDbCommand cmd = new OleDbCommand("Select * FROM tbResponses", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // var it = reader[2];
                        for (var i = 1; i < reader.VisibleFieldCount; i++)
                        {
                            res += reader[i].ToString() + ',';
                        }
                        res += Environment.NewLine;
                    }

                }
                conn.Close();
            }

           
            return res;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Create(List<Article> articles)
        {
            using (conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\USER\Dev\ELEN4010_DI\testDB.accdb"))
            {

                OleDbCommand cmd = new OleDbCommand("Insert into NewsResponses ([Time],[Content]) values(?,?)", conn);
                foreach (var toStore in articles)
                {
                    cmd.Parameters.AddWithValue("@Time", DateTime.Now.TimeOfDay);
                    cmd.Parameters.AddWithValue("@Body", toStore.Content);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                    }
                }
                
            }
        }
    }
}
