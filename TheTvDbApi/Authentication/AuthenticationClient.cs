using System;
using System.Net;
using System.Net.Http;
using RestSharp;

namespace TheTvDbApi.Authentication {
    internal class AuthenticationClient : IAuthenticationClient {
        private readonly TheTvDbClient _theTvDbClient;
        public string Token { get; private set; }

        public AuthenticationClient(TheTvDbClient theTvDbClient) {
            Token = string.Empty;
            _theTvDbClient = theTvDbClient;
        }

        public void Login(string apiKey, string userKey = "", string username = "") {
            var request = new RestRequest("login");
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;
            request.AddBody( new { apikey = apiKey, userkey = userKey, username } );
            var resonse = _theTvDbClient.HttpClient.Execute<TokenResponse>(request);
            if(resonse.StatusCode != HttpStatusCode.OK) {
                throw new HttpRestRequestException(resonse.StatusCode, resonse.Content);
            }
            Token = resonse.Data.Token;
        }

        public void RefreshToken() {
            var request = new RestRequest("refresh_token");
            request.Method = Method.GET;
            request.AddHeader( "Authorization", "Bearer " + Token );
            request.RequestFormat = DataFormat.Json;
            request.AddBody( new { token = Token } );
            var resonse = _theTvDbClient.HttpClient.Execute<TokenResponse>(request);
            if ( resonse.StatusCode != HttpStatusCode.OK ) {
                throw new HttpRestRequestException( resonse.StatusCode, resonse.Content );
            }
            Token = resonse.Data.Token;
        }
    }
}
