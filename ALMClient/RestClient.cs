using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ALMClient
{
    public class RestClient
    {

        protected CookieContainer cookies = new CookieContainer();

        public CookieContainer Cookies
        {
            get { return cookies; }
        }

        private HttpWebResponse Request(string url, string method, string accept, string contentType, CookieContainer cookie,
            Dictionary<string, string> headers, string data) 
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cookie;
            request.Method = method;
            if (!string.IsNullOrEmpty(accept))
            {
                request.Accept = accept;
            }
            if (!string.IsNullOrEmpty(contentType))
            {
                request.ContentType = contentType;
            }
            if (headers != null)
            {
                foreach (var pair in headers)
                {
                    request.Headers[pair.Key] = pair.Value;
                }
            }
            if (data != null)
            {
                byte[] dataStream = Encoding.UTF8.GetBytes(data);
                request.ContentLength = dataStream.Length;
                Stream newStream = request.GetRequestStream();
                // Send the data.
                newStream.Write(dataStream, 0, dataStream.Length);
                newStream.Close();
            }
            return (HttpWebResponse)request.GetResponse();
        }

        public HttpWebResponse GET(string url, string accept, string contentType, CookieContainer cookie, Dictionary<string, string> headers)
        {
            return Request(url, "GET", accept, contentType, cookie, headers, null);
        }

        public HttpWebResponse POST(string url, string accept, string contentType, CookieContainer cookie, Dictionary<string, string> headers, string data)
        {
            return Request(url, "POST", accept, contentType, cookie, headers, null);
        }

        public HttpWebResponse PUT(string url, string accept, string contentType, CookieContainer cookie, Dictionary<string, string> headers, string data)
        {
            return Request(url, "PUT", accept, contentType, cookie, headers, null);
        }

        public HttpWebResponse DELETE(string url, string accept, string contentType, CookieContainer cookie, Dictionary<string, string> headers)
        {
            return Request(url, "DELETE", accept, contentType, cookie, headers, null);
        }
    }

}
