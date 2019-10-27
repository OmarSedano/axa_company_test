using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WebApiClient.Exception
{
    public class HttpResponseException : System.Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public HttpResponseException(HttpStatusCode statusCode, string content) : base(content)
        {
            StatusCode = statusCode;
        }
    }
}
