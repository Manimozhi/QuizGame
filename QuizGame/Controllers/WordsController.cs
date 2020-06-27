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
using QuizGame.DataLogic;
using Microsoft.Extensions.Configuration;

namespace QuizGame.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<WordsController> _logger;

        public WordsController(IConfiguration configuration,ILogger<WordsController> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public static readonly Word[] Words=new Word[]
            {
                new Word{Id= 1, Name= "Hand", TamilWord="kai" },
                new Word{ Id= 2, Name= "Eye",TamilWord="kan" }
            };
        [HttpGet]
        public IEnumerable<Word> GetMock()
        {
            
            return Words.ToArray();
        }
        [HttpGet]
        public int Get()
        {
            var SFclient=new SalesForceClient(_configuration);
            var queryResponse=SFclient.ConnectandGet();
           
            return queryResponse.Result.Length;
        }
    }
}
