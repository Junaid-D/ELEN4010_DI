using System;
using DataInterfaces;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using NewsResponse;
using System.Collections.Generic;
using DataClasses;

namespace DB_man.DataAccess
{
    public class SqlDBAccess : IDataAccess
    {
        private OleDbConnection conn = null;
        public SqlDBAccess()
        {
        }

        public List<StoredArticle> Read()
        {
            List<StoredArticle> res = new List<StoredArticle>();
            using (conn = new OleDbConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {

                conn.Open();


                OleDbCommand cmd = new OleDbCommand("Select TOP 15 * FROM tbNewsResponses ORDER BY Time", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res.Add(new StoredArticle()
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Time = Convert.ToDateTime(reader["Time"]),
                            Content = Convert.ToString(reader["Content"])

                        });

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
                    if (toStore.Content != null)
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
}
