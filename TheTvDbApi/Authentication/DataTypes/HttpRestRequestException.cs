using System;
using System.Net;

namespace TheTvDbApi.Authentication {
    public class HttpRestRequestException : Exception {
        public HttpStatusCode StatusCode { get; }            
        public string Content { get; }

        public HttpRestRequestException(HttpStatusCode statusCode, string content) {
            StatusCode = statusCode;
            Content = content;
        }
    }
}
