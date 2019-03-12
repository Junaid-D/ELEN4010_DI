using System;

namespace DataClasses
{
    //as per the DB schema
    public class StoredArticle
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }
    }
}