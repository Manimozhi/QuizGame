using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizGame.Controllers;
using System.IO;
using System.Linq;

namespace Controller.Test
{
    [TestClass]
    public class ControllerUnitTest
    {
        private static  IConfiguration _configuration;
        private readonly ILogger<WordsController> _logger;
        public static IConfiguration InitConfiguration()
        {
            //var config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.test.json")
            //    .Build();
            //return config;
            var configbuilder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory() + @"\..\..\..")
              .AddJsonFile("appsettings.test.json", optional: false, reloadOnChange: true)
              .AddEnvironmentVariables()
              .Build();
            //  ConfigurationManager.Configuration = builder.Build();
            _configuration=configbuilder.GetSection("SalesForceConnection");
                return configbuilder;
        }
        
        [TestMethod]
        public void WordsMockDataTest()
        {
            InitConfiguration();
            var wordCtrl= new WordsController(_configuration,_logger);
            var outputResponse=wordCtrl.GetMock();
            Assert.IsTrue(outputResponse.Count() == 2, "Expected rows not found");
        }
        [TestMethod]
        public void WordsGetTest()
        {
            InitConfiguration();
            var wordCtrl = new WordsController(_configuration,_logger);
            var outputResponse = wordCtrl.Get();
            Assert.IsTrue(outputResponse == 2, "Expected rows not found");
        }
    }
}
