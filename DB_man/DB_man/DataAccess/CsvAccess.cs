﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterfaces;
using System.IO;
using NewsResponse;
using DataClasses;

namespace DB_man.DataAccess
{
    /// <summary>
    /// Implements CR(UD) operations on CSV files as a persistent store.
    /// </summary>
    public class CsvAccess : IDataAccess
    {
        private string fileName_;

        public CsvAccess()
        {
            fileName_ = System.Configuration.ConfigurationManager.ConnectionStrings["CSV"].ConnectionString;//fetch file name from config
        }

        public void Create(List<Article> articles)
        {
            using (StreamWriter file = new StreamWriter(fileName_))
            {
                foreach (var item in articles)
                {
                    try
                    {
                        if (item.Content != null)
                        {
                            var s = item.Content.Replace(Environment.NewLine, String.Empty);
                            file.WriteLine("{0},{1},\"{2}\"", "0", DateTime.Now.ToString(), s);//store story with timestamp and ID
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
        }


        public void Delete()//delete not currently needed within this application
        {
            throw new NotImplementedException();
        }

        public List<StoredArticle> Read()
        {
            List<StoredArticle> res = new List<StoredArticle>();
            try
            {
                using (var reader = new StreamReader(fileName_))
                {
                    var line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        var lineContents = line.Split(','); //split each line into fields
                        res.Add(new StoredArticle()
                        {
                            Id = Convert.ToInt32(lineContents[0]),
                            Time = Convert.ToDateTime(lineContents[1]),
                            Content = Convert.ToString(lineContents[2])

                        });
                    }
                }
            }
            catch (Exception e)
            {

            }

            return res;
        }

        public void Update()//Update not currently needed within this application
        {
            throw new NotImplementedException();
        }
    }
}
