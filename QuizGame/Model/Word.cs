using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGame.Model
{
    public class Word
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name{ get; set; }
        public string TamilWord{ get; set; }
        public string StartWith { get; set; }
    }
}
