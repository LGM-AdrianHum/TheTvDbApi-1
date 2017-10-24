using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Extensions;
using TheTvDbApi.Authentication;
using TheTvDbApi.Search;
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
            var request = new RestRequest("/series/" + id) { Method = Method.GET };
            request.AddHeader("Authorization", "Bearer " + _theTvDbClient.AuthenticationClient.Token);
            request.AddHeader("Accept-Language", Enum.GetName(typeof(Languages), _theTvDbClient.Language));
            request.RequestFormat = DataFormat.Json;
            var resonse = _theTvDbClient.HttpClient.Execute(request);
            if (resonse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRestRequestException(resonse.StatusCode, resonse.Content);
            }
            var data = JsonConvert.DeserializeObject<SeriesResponse>(resonse.Content);
            return data.Data;
        }

        public IEnumerable<ImageInfo> GetImages(int id, ImageTypes type)
        {
            var request = new RestRequest("series/" + id + "/images/query?keyType=" + Enum.GetName(typeof(ImageTypes), type));
            request.Method = Method.GET;
            request.AddHeader("Authorization", "Bearer " + _theTvDbClient.AuthenticationClient.Token);
            request.AddHeader("Accept-Language", Enum.GetName(typeof(Languages), _theTvDbClient.Language));
            request.RequestFormat = DataFormat.Json;
            var resonse = _theTvDbClient.HttpClient.Execute(request);
            if (resonse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRestRequestException(resonse.StatusCode, resonse.Content);
            }
            var data = JsonConvert.DeserializeObject<ImageResponse>(resonse.Content);
            return data.Data;
        }

        public IEnumerable<SeasonInfo> GetSeasonsAndEpisodes(int id)
        {

            IEnumerable<EpisodeInfo> episodeList = GetEpisodeList(id, 1);

            return InternalPackSeasons(episodeList);
        }

        private IEnumerable<EpisodeInfo> GetEpisodeList(int id, int page)
        {

            List<EpisodeInfo> episodes = new List<EpisodeInfo>();

            var request = new RestRequest("series/" + id + "/episodes/query?page=" + page);
            request.Method = Method.GET;
            request.AddHeader("Authorization", "Bearer " + _theTvDbClient.AuthenticationClient.Token);
            request.AddHeader("Accept-Language", Enum.GetName(typeof(Languages), _theTvDbClient.Language));
            request.RequestFormat = DataFormat.Json;
            var resonse = _theTvDbClient.HttpClient.Execute(request);
            if (resonse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRestRequestException(resonse.StatusCode, resonse.Content);
            }

            var data = JsonConvert.DeserializeObject<EpisodeResponse>(resonse.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            if (data.Links.Next > page)
                episodes.AddRange(GetEpisodeList(id, page + 1));

            episodes.AddRange(data.data);

            return episodes;
        }

        private IEnumerable<SeasonInfo> InternalPackSeasons(IEnumerable<EpisodeInfo> episodeList)
        {
            List<SeasonInfo> seasonList = new List<SeasonInfo>();

            SeasonInfo season = null;
            foreach (var episode in episodeList.OrderBy(x => x.AiredSeason).ThenBy(x => x.AiredEpisodeNumber))
            {
                if (season == null || season.AiredNumber != episode.AiredSeason)
                {
                    season = new SeasonInfo();
                    season.AiredNumber = episode.AiredSeason;
                    season.DvdNumber = episode.DvdSeason;

                    seasonList.Add(season);
                }
                season.EpisodeList.Add(episode);
            }

            return seasonList;
        }
    }
}
