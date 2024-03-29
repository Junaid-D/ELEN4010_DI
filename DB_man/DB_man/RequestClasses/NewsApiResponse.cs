﻿// <auto-generated />
//Using QuickType

/// <summary>
/// This code is used to deserialise JSON strings into a data class (NewsData), or to serialize from the class. This code is automatically generated by the QuickType online tool.
/// </summary>
namespace NewsResponse
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class NewsData
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("totalResults")]
        public long TotalResults { get; set; }

        [JsonProperty("articles")]
        public List<Article> Articles { get; set; }
    }

    public partial class Article
    {
        [JsonProperty("source")]
        public Source Source { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("urlToImage")]
        public Uri UrlToImage { get; set; }

        [JsonProperty("publishedAt")]
        public DateTimeOffset PublishedAt { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public partial class Source
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class NewsData
    {
        public static NewsData FromJson(string json) => JsonConvert.DeserializeObject<NewsData>(json, NewsResponse.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this NewsData self) => JsonConvert.SerializeObject(self, NewsResponse.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
