<<<<<<< HEAD
﻿using System.Net.Http;
using RestSharp;
using TheTvDbApi.Authentication;
using TheTvDbApi.Episode;
using TheTvDbApi.Search;
using TheTvDbApi.Series;
using TheTvDbApi.Updates;

namespace TheTvDbApi
{
    public class TheTvDbClient
    {
        private readonly AuthenticationClient _authenticationClient;

        public IAuthenticationClient AuthenticationClient => _authenticationClient;

        public IUpdateClient UpdateClient { get; }
        public ISearchClient SearchClient { get; }
        public ISeriesClient SeriesClient { get; }
        public IEpisodeClient EpisodeClient { get; }
        public Languages Language { get; set; }
        internal RestClient HttpClient { get; }

        public TheTvDbClient(string apiKey, string userkey = "", string username = "")
        {
            HttpClient = new RestClient("https://api.thetvdb.com/");

            Language = Languages.En;

            _authenticationClient = new AuthenticationClient(this);
            _authenticationClient.Login(apiKey, userkey, username);

            SearchClient = new SearchClient(this);
            SeriesClient = new SeriesClient(this);
            EpisodeClient = new EpisodeClient(this);
            UpdateClient = new UpdateClient(this);
        }
    }
}
=======
﻿//  _____ _        _____    ______ _      ___        _   
// |_   _| |      |_   _|   |  _  \ |    / _ \      (_)  
//   | | | |__   ___| |_   _| | | | |__ / /_\ \_ __  _   
//   | | | '_ \ / _ \ \ \ / / | | | '_ \|  _  | '_ \| |  
//   | | | | | |  __/ |\ V /| |/ /| |_) | | | | |_) | |_ 
//   \_/ |_| |_|\___\_/ \_/ |___/ |_.__/\_| |_/ .__/|_(_)
//                                            | |        
//                                            |_|        
// 
// Module   : TheTvDbApi/TheTvDbApi/TheTvDbClient.cs
// Name     : Adrian Hum - adrianhum 
// Created  : 2017-10-27-7:39 AM
// Modified : 2017-10-27-7:46 AM

using RestSharp;
using TheTvDbApi.Authentication;
using TheTvDbApi.Episode;
using TheTvDbApi.Search;
using TheTvDbApi.Series;
using TheTvDbApi.Updates;

namespace TheTvDbApi
{
    public class TheTvDbClient
    {
        private readonly AuthenticationClient _authenticationClient;

        public TheTvDbClient(string apiKey, string userkey = "", string username = "")
        {
            HttpClient = new RestClient("https://api.thetvdb.com/");

            Language = Languages.En;

            _authenticationClient = new AuthenticationClient(this);
            _authenticationClient.Login(apiKey, userkey, username);

            SearchClient = new SearchClient(this);
            SeriesClient = new SeriesClient(this);
            EpisodeClient = new EpisodeClient(this);
            UpdateClient = new UpdateClient(this);
        }

        public IAuthenticationClient AuthenticationClient => _authenticationClient;

        public IUpdateClient UpdateClient { get; }
        public ISearchClient SearchClient { get; }
        public ISeriesClient SeriesClient { get; }
        public IEpisodeClient EpisodeClient { get; }
        public Languages Language { get; set; }
        internal RestClient HttpClient { get; }
    }
}
>>>>>>> 460629e6741991f642b92ca3c4200e7a9b1bd8a0
