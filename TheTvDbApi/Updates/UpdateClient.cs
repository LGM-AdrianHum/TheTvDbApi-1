//  _____ _        _____    ______ _      ___        _   
// |_   _| |      |_   _|   |  _  \ |    / _ \      (_)  
//   | | | |__   ___| |_   _| | | | |__ / /_\ \_ __  _   
//   | | | '_ \ / _ \ \ \ / / | | | '_ \|  _  | '_ \| |  
//   | | | | | |  __/ |\ V /| |/ /| |_) | | | | |_) | |_ 
//   \_/ |_| |_|\___\_/ \_/ |___/ |_.__/\_| |_/ .__/|_(_)
//                                            | |        
//                                            |_|        
// 
// Module   : TheTvDbApi/TheTvDbApi/UpdateClient.cs
// Name     : Adrian Hum - adrianhum 
// Created  : 2017-10-26-5:16 PM
// Modified : 2017-10-27-7:19 AM

using System;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TheTvDbApi.Authentication;

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
            var request = new RestRequest(req) {Method = Method.GET};
            request.AddHeader("Authorization", "Bearer " + _theTvDbClient.AuthenticationClient.Token);
            request.AddHeader("Accept-Language", Enum.GetName(typeof(Languages), _theTvDbClient.Language));
            request.RequestFormat = DataFormat.Json;
            var resonse = _theTvDbClient.HttpClient.Execute(request);
            if (resonse.StatusCode != HttpStatusCode.OK)
                throw new HttpRestRequestException(resonse.StatusCode, resonse.Content);
            var data = JsonConvert.DeserializeObject<UpdateSeriesResponse>(resonse.Content);
            data.FromEpochTime = epochFromTime;
            data.ToEpochTime = epochToTime;
            return data.Data;
        }
    }


    public class UpdatedSeries
    {
        public int id { get; set; }
        public int lastUpdated { get; set; }
    }
}