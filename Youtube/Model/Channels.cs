using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Interfaces;

namespace Youtube.Model
{
    public class Channels : IMultimedia
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("statistics")]
        public Statistics statistics { get; set; }
        [JsonProperty("brandingSettings")]
        public Brandingsettings brandingSettings { get; set; }


        public class Statistics
        {
            [JsonProperty("viewCount")]
            public ulong? viewCount { get; set; }
            [JsonProperty("subscriberCount")]
            public ulong? subscriberCount { get; set; }
            [JsonProperty("videoCount")]
            public ulong? videoCount { get; set; }
        }

        public class Brandingsettings
        {
            [JsonProperty("channel")]
            public Descri channel { get; set; }
        }

        public class Descri
        {
            [JsonProperty("title")]
            public string title { get; set; }
            [JsonProperty("description")]
            public string description { get; set; }
            [JsonProperty("keywords")]
            public string keywords { get; set; }
            [JsonProperty("featuredChannelsUrls")]
            public string[] featuredChannelsUrls { get; set; }
        }




    }
}
