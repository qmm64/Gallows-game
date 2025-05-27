using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallows_game
{

    internal class Game
    {
        //хранение текущего слова 
        public string Word { get; private set; }

        //хранение списка введенных букв 
        private HashSet<char> guessedLetters = new HashSet<char>();
        private HashSet<char> wrongLetters = new HashSet<char>();
        public int MaxErrors { get; private set; } = 6;

        //счетчика ошибок 
        public int Errors => wrongLetters.Count;

        public Game(string word)
        {
            Word = word.ToUpper();
        }

    }
}
