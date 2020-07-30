using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TelerikAspNetCoreApp2.Helper
{
    public class UserApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:270371/");

            return client;
        }
    }
}
