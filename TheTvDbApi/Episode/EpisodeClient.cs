//  _____ _        _____    ______ _      ___        _   
// |_   _| |      |_   _|   |  _  \ |    / _ \      (_)  
//   | | | |__   ___| |_   _| | | | |__ / /_\ \_ __  _   
//   | | | '_ \ / _ \ \ \ / / | | | '_ \|  _  | '_ \| |  
//   | | | | | |  __/ |\ V /| |/ /| |_) | | | | |_) | |_ 
//   \_/ |_| |_|\___\_/ \_/ |___/ |_.__/\_| |_/ .__/|_(_)
//                                            | |        
//                                            |_|        
// 
// Module   : TheTvDbApi.Support/TheTvDbApi/EpisodeClient.cs
// Name     : Adrian Hum - adrianhum 
// Created  : 2017-10-27-7:39 AM
// Modified : 2017-11-04-1:10 PM

using System;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TheTvDbApi.Authentication;
using TheTvDbApi.Episode.DataTypes;

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
			var request = new RestRequest("/episodes/" + id) {Method = Method.GET};
			request.AddHeader("Authorization", $"Bearer {_theTvDbClient.AuthenticationClient.Token}");
			request.AddHeader("Accept-Language", Enum.GetName(typeof(Languages), _theTvDbClient.Language));
			request.RequestFormat = DataFormat.Json;
			var resonse = _theTvDbClient.HttpClient.Execute(request);
			if (resonse.StatusCode != HttpStatusCode.OK)
				throw new HttpRestRequestException(resonse.StatusCode, resonse.Content);
			var data = JsonConvert.DeserializeObject<EpisodeFullResponse>(resonse.Content,
				new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
			return data.data;
		}
	}
}