using System;
using System.Net.Http.Headers;

namespace Post.Core.Dto.Request
{
    public class RequestDto
    {
        public string Method { get; set; }
        public string HttpVersion { get; set; }
        public Uri RequestUri { get; set; }
        public string Content { get; set; }
        public HttpRequestHeaders Headers { get; set; }
    }
}