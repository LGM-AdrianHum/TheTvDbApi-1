using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using TheTvDbApi.Authentication;
using TheTvDbApi.Series;
using TheTvDbApi.Updates.DataTypes;

namespace TheTvDbApi.Updates
{
    public class UpdateClient : IUpdateClient
    {
        private readonly TheTvDbClient _theTvDbClient;

        public UpdateClient(TheTvDbClient theTvDbClient)
        {
            _theTvDbClient = theTvDbClient;
        }

        public UpdatedSeries[] Get(DateTime fromTime, DateTime? toTime = null)
        {
            return Get(fromTime.ToUnixTime(), toTime?.ToUnixTime() ?? -1);
        }

        public UpdatedSeries[] Get(long epochFromTime, long epochToTime = -1)
        {
            var req = $"/updated/query?fromTime={epochFromTime}";
            if (epochToTime != -1) req += $"&toTime={epochToTime}";
            var request = new RestRequest(req) { Method = Method.GET };
            request.AddHeader("Authorization", "Bearer " + _theTvDbClient.AuthenticationClient.Token);
            request.AddHeader("Accept-Language", Enum.GetName(typeof(Languages), _theTvDbClient.Language));
            request.RequestFormat = DataFormat.Json;
            var resonse = _theTvDbClient.HttpClient.Execute(request);
            if (resonse.StatusCode != HttpStatusCode.OK)
                throw new HttpRestRequestException(resonse.StatusCode, resonse.Content);
            var data = JsonConvert.DeserializeObject<UpdateSeriesResponse>(resonse.Content);
            data.FromEpochTime = epochFromTime;
            data.ToEpochTime = epochToTime;
            return data.data;
        }


    }


    public class UpdatedSeries
    {
        public int id { get; set; }
        public int lastUpdated { get; set; }
    }

}
