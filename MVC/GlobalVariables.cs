using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MVC
{
    public static class GlobalVariables
    {
        
            public static HttpClient WebApiClient = new HttpClient();
            static GlobalVariables()
            {
                WebApiClient.BaseAddress = new Uri("http://localhost:11763/api");
                WebApiClient.DefaultRequestHeaders.Clear();
                WebApiClient.DefaultRequestHeaders.Add("Accept", "application/json");
            }
        
    }
}