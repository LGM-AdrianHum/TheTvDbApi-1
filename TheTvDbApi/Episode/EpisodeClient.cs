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
using TheTvDbApi.Episode.DataTypes;
using TheTvDbApi.Search;
using TheTvDbApi.Series.DataTypes;

namespace TheTvDbApi.Episode
{
    public class EpisodeClient : IEpisodeClient
    {
        private readonly TheTvDbClient _theTvDbClient;

        public EpisodeClient(TheTvDbClient theTvDbClient)
        {
            _theTvDbClient = theTvDbClient;
        }

        public EpisodeFullInfo Get(int id)
        {
            var request = new RestRequest("/episodes/" + id) { Method = Method.GET };
            request.AddHeader("Authorization", "Bearer " + _theTvDbClient.AuthenticationClient.Token);
            request.AddHeader("Accept-Language", Enum.GetName(typeof(Languages), _theTvDbClient.Language));
            request.RequestFormat = DataFormat.Json;
            var resonse = _theTvDbClient.HttpClient.Execute(request);
            if (resonse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRestRequestException(resonse.StatusCode, resonse.Content);
            }
            var data = JsonConvert.DeserializeObject<EpisodeFullResponse>(resonse.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return data.data;
        }
    }
}
