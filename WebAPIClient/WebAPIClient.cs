using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public partial class WebAPIClient
    {
        private static HttpClient _httpClient = null;
        private static readonly string baseUrl = ConfigurationManager.AppSettings["APIUrl"];

        public WebAPIClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }        

        public static class Controller
        {
            public static string Machines
            {
                get { return "api/Machines"; }
            }

            public static string Tools
            {
                get { return "api/Tools"; }
            }

            public static string MachineTools
            {
                get { return "api/MachineTools"; }
            }

            public static string Turrets
            {
                get { return "api/Turrets"; }
            }
        }
    }
}
