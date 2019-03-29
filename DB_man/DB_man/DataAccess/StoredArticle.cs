using System;

namespace DataClasses
{
    /// <summary>
    /// Data class: Represents the format of a stored story as per the db/csv schema.
    /// </summary>
    public class StoredArticle
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }
    }
}