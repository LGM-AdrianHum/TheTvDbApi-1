using System.Net.Http;
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
