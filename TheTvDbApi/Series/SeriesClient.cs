using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Extensions;
using TheTvDbApi.Authentication;
using TheTvDbApi.Search;

namespace TheTvDbApi.Series {
    public class SeriesClient : ISeriesClient {
        private readonly TheTvDbClient _theTvDbClient;

        public SeriesClient(TheTvDbClient theTvDbClient) {
            _theTvDbClient = theTvDbClient;
        }

        public SerieInfo Get(int id) {
            var request = new RestRequest("/series/" + id);
            request.Method = Method.GET;
            request.AddHeader( "Authorization", "Bearer " + _theTvDbClient.AuthenticationClient.Token );
            request.RequestFormat = DataFormat.Json;
            var resonse = _theTvDbClient.HttpClient.Execute(request);
            if ( resonse.StatusCode != HttpStatusCode.OK ) {
                throw new HttpRestRequestException( resonse.StatusCode, resonse.Content );
            }
            var data = JsonConvert.DeserializeObject<SeriesResponse>(resonse.Content);
            return data.Data;
        }

        public IEnumerable<ImageInfo> GetImages(int id, ImageTypes type) {
            var request = new RestRequest("series/" +id+ "/images/query?keyType=" + Enum.GetName(typeof(ImageTypes), type));
            request.Method = Method.GET;
            request.AddHeader( "Authorization", "Bearer " + _theTvDbClient.AuthenticationClient.Token );
            request.RequestFormat = DataFormat.Json;
            var resonse = _theTvDbClient.HttpClient.Execute(request);
            if ( resonse.StatusCode != HttpStatusCode.OK ) {
                throw new HttpRestRequestException( resonse.StatusCode, resonse.Content );
            }
            var data = JsonConvert.DeserializeObject<ImageResponse>(resonse.Content);
            return data.Data;
        }
    }
}
