using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TheTvDbApi.Authentication;
using RestRequest = RestSharp.RestRequest;

namespace TheTvDbApi.Search {
    public class SearchClient : ISearchClient {
        private readonly TheTvDbClient _theTvDbClient;

        public SearchClient(TheTvDbClient theTvDbClient) {
            _theTvDbClient = theTvDbClient;
        }

        public IEnumerable<SearchResult> Search(string name) {
            var request = new RestRequest("search/series?name=" + name);
            request.Method = Method.GET;
            request.AddHeader( "Authorization", "Bearer " + _theTvDbClient.AuthenticationClient.Token );
            request.RequestFormat = DataFormat.Json;
            var resonse = _theTvDbClient.HttpClient.Execute(request);
            if ( resonse.StatusCode != HttpStatusCode.OK ) {
                throw new HttpRestRequestException( resonse.StatusCode, resonse.Content );
            }
            var data = JsonConvert.DeserializeObject<SearchResponse>(resonse.Content);
            return data.Data;
        }
    }
}