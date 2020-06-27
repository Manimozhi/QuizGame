using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using QuizGame.Model;
using IntegrateSalesforceRESTApi;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace QuizGame.DataLogic
{
    public class SalesForceClient
    {
        public static class Constants
        {
            public static string USERNAME = "REPLACE WITH YOUR USERNAME";
            public static string PASSWORD = "REPLACE WITH YOUR PASSWORD";
            public static string TOKEN = "REPLACE WITH YOUR SECURITY TOKEN";
            public static string CONSUMER_KEY = "REPLACE WITH YOUR CONNECTED APP CONSUMER KEY";
            public static string CONSUMER_SECRET = "REPLACE WITH YOUR CONNECTED APP CONSUMER SECRET";
            public static string APIVERSION = "REPLACE WITH YOUR ";
            public static string TOKEN_REQUEST_ENDPOINTURL = "https://login.salesforce.com/services/oauth2/token";
            public static string TOKEN_REQUEST_QUERYURL = "/services/data/v43.0/query?q=select+Id+,name+from+account+limit+10";
        }
        public SalesForceClient(IConfiguration configuration)
        {
            Constants.USERNAME=configuration.GetValue<string>("username");
            Constants.PASSWORD= configuration.GetValue<string>("password");
            Constants.TOKEN = configuration.GetValue<string>("security.token");
            Constants.CONSUMER_KEY = configuration.GetValue<string>("consumer.key");
            Constants.CONSUMER_SECRET = configuration.GetValue<string>("consumer.secret");
            Constants.APIVERSION = configuration.GetValue<string>("api.version");

        }
        public Task<string> ConnectandGet()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Task<JObject> authResponse = Task.Run(() => SalesForceClient.AsyncAuthRequest());
            Task<string> leadResponse = null;
            authResponse.Wait();
            if (authResponse.Result != null)
            {
                leadResponse = Task.Run(() => SalesForceClient.AsyncQueryRequest(authResponse.Result.Value<string>("access_token"), authResponse.Result.Value<string>("instance_url")));
                leadResponse.Wait();
            }
            return leadResponse;
        }
        public static async  Task<JObject> AsyncAuthRequest()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("client_id", Constants.CONSUMER_KEY),
                new KeyValuePair<string, string>("client_secret", Constants.CONSUMER_SECRET),
                new KeyValuePair<string, string>("username", Constants.USERNAME),
                new KeyValuePair<string, string>("password", Constants.PASSWORD + Constants.TOKEN)
            });
            HttpClient _httpClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Constants.TOKEN_REQUEST_ENDPOINTURL),
                Content = content
            };
            var responseMessage = await _httpClient.SendAsync(request).ConfigureAwait(false);
            var response = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            JObject responseDyn = (JObject)JsonConvert.DeserializeObject(response);

            return responseDyn;
        }
        public static async  Task<string> AsyncQueryRequest(string token, string url)
        {
            HttpClient _httpClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url + Constants.TOKEN_REQUEST_QUERYURL),
                Content = null
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await new HttpClient().SendAsync(request).ConfigureAwait(false);
            var response = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return response;
        }

    }
}
