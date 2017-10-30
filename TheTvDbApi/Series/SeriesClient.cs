//  _____ _        _____    ______ _      ___        _   
// |_   _| |      |_   _|   |  _  \ |    / _ \      (_)  
//   | | | |__   ___| |_   _| | | | |__ / /_\ \_ __  _   
//   | | | '_ \ / _ \ \ \ / / | | | '_ \|  _  | '_ \| |  
//   | | | | | |  __/ |\ V /| |/ /| |_) | | | | |_) | |_ 
//   \_/ |_| |_|\___\_/ \_/ |___/ |_.__/\_| |_/ .__/|_(_)
//                                            | |        
//                                            |_|        
// File: TheTvDbApi/TheTvDbApi/SeriesClient.cs
// User: Adrian Hum/
// 
// Created:  2017-10-23 5:16 PM
// Modified: 2017-10-26 5:15 PM

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TheTvDbApi.Authentication;
using TheTvDbApi.Series.DataTypes;

namespace TheTvDbApi.Series
{
    public class SeriesClient : ISeriesClient
    {
        private readonly TheTvDbClient _theTvDbClient;

        public SeriesClient(TheTvDbClient theTvDbClient)
        {
            _theTvDbClient = theTvDbClient;
        }

        public SerieInfo Get(int id)
        {
            var request = new RestRequest("/series/" + id) {Method = Method.GET};
            request.AddHeader("Authorization", "Bearer " + _theTvDbClient.AuthenticationClient.Token);
            request.AddHeader("Accept-Language", Enum.GetName(typeof(Languages), _theTvDbClient.Language));
            request.RequestFormat = DataFormat.Json;
            var resonse = _theTvDbClient.HttpClient.Execute(request);
            if (resonse.StatusCode != HttpStatusCode.OK)
                throw new HttpRestRequestException(resonse.StatusCode, resonse.Content);
            var data = JsonConvert.DeserializeObject<SeriesResponse>(resonse.Content);
            return data.Data;
        }

        public IEnumerable<ImageInfo> GetImages(int id, ImageTypes type)
        {
            var request =
                new RestRequest("series/" + id + "/images/query?keyType=" + Enum.GetName(typeof(ImageTypes), type))
                {
                    Method = Method.GET
                };
            request.AddHeader("Authorization", "Bearer " + _theTvDbClient.AuthenticationClient.Token);
            request.AddHeader("Accept-Language", Enum.GetName(typeof(Languages), _theTvDbClient.Language));
            request.RequestFormat = DataFormat.Json;
            var resonse = _theTvDbClient.HttpClient.Execute(request);
            if (resonse.StatusCode != HttpStatusCode.OK)
                throw new HttpRestRequestException(resonse.StatusCode, resonse.Content);
            var data = JsonConvert.DeserializeObject<ImageResponse>(resonse.Content);
            return data.Data;
        }

        public IEnumerable<Actors> GetActors(int id)
        {
            var actorList = new List<Actors>();
            var request = new RestRequest($"series/{id}/actors") { Method = Method.GET };
            request.AddHeader("Authorization", "Bearer " + _theTvDbClient.AuthenticationClient.Token);
            request.AddHeader("Accept-Language", Enum.GetName(typeof(Languages), _theTvDbClient.Language));
            request.RequestFormat = DataFormat.Json;
            var response = _theTvDbClient.HttpClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRestRequestException(response.StatusCode, response.Content);
            var data = JsonConvert.DeserializeObject<ActorsResponse>(response.Content,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return data.Data;
        }

        public IEnumerable<SeasonInfo> GetSeasonsAndEpisodes(int id)
        {
            var episodeList = GetEpisodeList(id, 1);

            return InternalPackSeasons(episodeList);
        }

        private IEnumerable<EpisodeInfo> GetEpisodeList(int id, int page)
        {
            var episodes = new List<EpisodeInfo>();

            var request = new RestRequest($"series/{id}/episodes/query?page={page}") {Method = Method.GET};
            request.AddHeader("Authorization", "Bearer " + _theTvDbClient.AuthenticationClient.Token);
            request.AddHeader("Accept-Language", Enum.GetName(typeof(Languages), _theTvDbClient.Language));
            request.RequestFormat = DataFormat.Json;
            var response = _theTvDbClient.HttpClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRestRequestException(response.StatusCode, response.Content);

            var data = JsonConvert.DeserializeObject<EpisodeResponse>(response.Content,
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

            if (data.Links.Next > page) episodes.AddRange(GetEpisodeList(id, page + 1));

            episodes.AddRange(data.data);

            return episodes;
        }

        private static IEnumerable<SeasonInfo> InternalPackSeasons(IEnumerable<EpisodeInfo> episodeList)
        {
            var seasonList = new List<SeasonInfo>();

            SeasonInfo season = null;
            foreach (var episode in episodeList.OrderBy(x => x.AiredSeason).ThenBy(x => x.AiredEpisodeNumber))
            {
                if (season == null || season.AiredNumber != episode.AiredSeason)
                {
                    season = new SeasonInfo
                    {
                        AiredNumber = episode.AiredSeason,
                        DvdNumber = episode.DvdSeason
                    };

                    seasonList.Add(season);
                }
                season.EpisodeList.Add(episode);
            }

            return seasonList;
        }
    }
}