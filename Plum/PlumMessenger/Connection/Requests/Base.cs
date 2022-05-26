using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace PlumMessenger.Connection.Requests
{
    public class Base
    {
        protected Base(string host) {
            string Host = "http://127.0.0.1:5000";

            if (ClientCreator.Client == null)
            {
                Host = host == null ? Host : host;

                CookieContainer cookieContainer = new CookieContainer();
                HttpClientHandler clienthandler = new HttpClientHandler { 
                    AllowAutoRedirect = true,
                    UseCookies = true,
                    CookieContainer = cookieContainer
                };

                ClientCreator.Client = new HttpClient(clienthandler);

                Client.BaseAddress = new Uri(Host);
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        private sealed class ClientCreator
        {
            private static HttpClient client = null;
            public static HttpClient Client { get { return client; } set { client = value; } }
        }

        public static HttpClient Client
        {
            get { return ClientCreator.Client; }
        }
    }
}
