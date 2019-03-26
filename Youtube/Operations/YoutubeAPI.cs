using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Interfaces;
using Youtube.Model;
using static Youtube.Model.Channels;


namespace Youtube.Operations
{
    public class YoutubeAPI : IYoutubeAPI
    {
        public YouTubeService youtubeService()
        {
            return new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "---------------KEY---------------------",
                ApplicationName = this.GetType().ToString()
            });
        }

        public async Task<List<IMultimedia>> youtubeSearch(string name, int max)
        {
            var searchListRequest = youtubeService().Search.List("snippet");
            searchListRequest.Q = name;
            searchListRequest.MaxResults = max;

            var searchListResponse = await searchListRequest.ExecuteAsync();
            if (searchListResponse.Items.Count == 0)
                return null;

            List<IMultimedia> result = new List<IMultimedia>();

            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        result.Add(new Video { Title = searchResult.Snippet.Title, VideoId = searchResult.Id.VideoId });
                        break;

                    case "youtube#channel":

                        result.Add(new Channels
                        {
                            id = searchResult.Id.ChannelId,
                            brandingSettings = new Brandingsettings
                            {
                                channel = new Descri
                                { title = searchResult.Snippet.Title }
                            }
                        });
                        break;

                    case "youtube#playlist":
                        result.Add(new Playlist { Title = searchResult.Snippet.Title, PlaylistId = searchResult.Id.PlaylistId });
                        break;
                }
            }
            return result;
        }
        public async Task<Channels> youtubeSubs(string name, int max)
        {
            var subsList = youtubeService().Channels.List("statistics, brandingSettings");
            subsList.Id = name;
            subsList.MaxResults = max;
            var subsListResponse = await subsList.ExecuteAsync();

            Channels channel = new Channels {
                id = subsListResponse.Items.Select(s=>s.Id).FirstOrDefault(),
                statistics= new Statistics
                {
                    subscriberCount = subsListResponse.Items.Select(s => s.Statistics.SubscriberCount).FirstOrDefault(),
                    videoCount = subsListResponse.Items.Select(s => s.Statistics.VideoCount).FirstOrDefault(),
                    viewCount = subsListResponse.Items.Select(s => s.Statistics.ViewCount).FirstOrDefault()

                },
                brandingSettings = new Brandingsettings
                {
                    
                    channel = new Descri
                    {
                        description = subsListResponse.Items.Select(s=>s.BrandingSettings.Channel.Description).FirstOrDefault(),
                        title = subsListResponse.Items.Select(s => s.BrandingSettings.Channel.Title).FirstOrDefault(),
                        keywords = subsListResponse.Items.Select(s => s.BrandingSettings.Channel.Keywords).FirstOrDefault(),
                        featuredChannelsUrls = subsListResponse.Items.SelectMany(s => s.BrandingSettings.Channel.FeaturedChannelsUrls).ToArray()
                    }
                }
            };

            return channel;
        }
    }
}
