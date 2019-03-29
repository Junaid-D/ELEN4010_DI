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
    /// <summary>
    /// Implements CR(UD) operatiosn on Access database.
    /// </summary>

    public class SqlDBAccess : IDataAccess
    {
        private OleDbConnection conn = null;
        public SqlDBAccess()
        {
        }

        public List<StoredArticle> Read()
        {
            List<StoredArticle> res = new List<StoredArticle>();
            using (conn = new OleDbConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString))//connection string from config
            {

                conn.Open();


                OleDbCommand cmd = new OleDbCommand("Select TOP 15 * FROM tbNewsResponses ORDER BY Time", conn);//SQL query for retrieving new stories fro db.
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

        public void Update()//Update not needed for current implementation.
        {
            throw new NotImplementedException();
        }

        public void Delete()//Delete not needed for current implementation.
        {
            throw new NotImplementedException();
        }

        public void Create(List<Article> articles)
        {
            using (conn = new OleDbConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {

                OleDbCommand cmd = new OleDbCommand("Insert into tbNewsResponses ([Time],[Content]) values(?,?)", conn);//Sql query with parameters
                foreach (var toStore in articles)
                {
                    if (toStore.Content != null)
                    {
                        cmd.Parameters.AddWithValue("@Time", DateTime.Now.TimeOfDay);//store with timestamp
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
