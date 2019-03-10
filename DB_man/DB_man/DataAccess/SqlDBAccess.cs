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
            using (conn = new OleDbConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {

                conn.Open();


                OleDbCommand cmd = new OleDbCommand("Select TOP 15 * FROM tbNewsResponses ORDER BY Time", conn);
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
            using (conn = new OleDbConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand("Insert into tbNewsResponses ([Time],[Content]) values(?,?)", conn);
                foreach (var toStore in articles)
                {
                    cmd.Parameters.AddWithValue("@Time", DateTime.Now.TimeOfDay);
                    cmd.Parameters.AddWithValue("@Content", toStore.Content);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        cmd.Parameters.Clear();
                    }
                    catch (Exception e)
                    {
                    }
                }

            }
        }
    }
}
