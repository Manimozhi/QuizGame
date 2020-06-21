using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizGame.Model;

namespace QuizGame.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private static readonly Category[] Categories = new Category[]
        {
            new Category{ Id= 1, Name= "General" },
            new Category{ Id= 2, Name="Simple" },
            new Category{ Id= 3, Name="Numbers" },
            new Category{ Id= 4, Name="Colors" },
            new Category{ Id= 5, Name="Birds" },
            new Category{ Id= 6, Name="Animals" },
            new Category{ Id= 7, Name="Body Parts" },
            new Category{ Id= 8, Name="Relations" },
            new Category{ Id= 9, Name="Question" },
            new Category{ Id= 10, Name="Letters" },
            new Category{ Id= 11, Name="Action" },
            new Category{ Id= 12, Name="Home" },
            new Category{ Id= 13, Name="Relegion" },
            new Category{ Id= 14, Name="Cha-series" },
            new Category{ Id= 15, Name="Direction" },
        };
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return Categories;
        }
    }
}
