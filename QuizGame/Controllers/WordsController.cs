using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using QuizGame.Model;


namespace QuizGame.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly ILogger<WordsController> _logger;

        public WordsController(ILogger<WordsController> logger)
        {
            _logger = logger;
        }
        private static readonly Word[] Words=new Word[]
            {
                new Word{Id= 1, Name= "Hand", TamilWord="kai" },
                new Word{ Id= 2, Name= "Eye",TamilWord="kan" }
            };
        [HttpGet]
        public IEnumerable<Word> Get()
        {
            //string USERNAME = "REPLACE WITH YOUR USERNAME";
            //string PASSWORD = "REPLACE WITH YOUR PASSWORD";
            //string TOKEN = "REPLACE WITH YOUR SECURITY TOKEN";
            //string CONSUMER_KEY = "REPLACE WITH YOUR CONNECTED APP CONSUMER KEY";
            //string CONSUMER_SECRET = "REPLACE WITH YOUR CONNECTED APP CONSUMER SECRET";
            //string TOKEN_REQUEST_ENDPOINTURL = "https://login.salesforce.com/services/oauth2/token";
            //string TOKEN_REQUEST_QUERYURL = "/services/data/v43.0/query?q=select+Id+,name+from+account+limit+10";

            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //Task authResponse = Task.Run(() => WordsController.AsyncAuthRequesult != null)
            //{
            //    Object obj = AsyncQueryRequest();
            //}
            //{
            //    new KeyValuePair<string, string>("grant_type", "password"),
            //new KeyValuePair<string, string>("client_id", CONSUMER_KEY),
            //new KeyValuePair<string, string>("client_secret", CONSUMER_SECRET),
            //new KeyValuePair<string, string>("username", USERNAME),
            //new KeyValuePair<string, string>("password", PASSWORD + TOKEN)
            //});
            //HttpClient _httpClient = new HttpClient();
            //var request = new HttpRequestMessage<br />
            //{
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri(Constants.TOKEN_REQUEST_ENDPOINTURL),
            //    Content = content
            //};
            //var responseMessage = await _httpClient.SendAsync(request).ConfigureAwait(false);
            //var response = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return Words;
        }
    }
}
