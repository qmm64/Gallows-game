using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        //проверка угадал ли букву
        public bool CheckLetter(char letter)
        {
            letter = char.ToUpper(letter);

            if (guessedLetters.Contains(letter) || wrongLetters.Contains(letter))
                return false;

            if (Word.Contains(letter))
            {
                guessedLetters.Add(letter);
                return true;
            }
            else
            {
                wrongLetters.Add(letter);
                return false;
            }
        }

        // отображение угадываемого слова
        public string GetCurrentProgress() 
        {
            char[] display = Word.Select(ch => guessedLetters.Contains(ch) ? ch : '_').ToArray();
            return string.Join(" ", display);
        }
        public IEnumerable<char> GetWrongLetters()
        {
            return wrongLetters.OrderBy(c => c);
        }
        public IEnumerable<char> GetGuessedLetters()
        {
            return guessedLetters.OrderBy(c => c);
        }
        
        // проверка на окончание игры
        public GameState CheckGameState() 
        {
            if (Word.All(ch => guessedLetters.Contains(ch)))
            {
                return GameState.Win;
            }
            if (Errors >= MaxErrors)
            {
                return GameState.Lose;
            }
            return GameState.Ongoing;

        }
        public void Restart(string newWord)
        {
            Word = newWord.ToUpper();
            guessedLetters.Clear();
            wrongLetters.Clear();
        }

        private string GetWordFromCategory(Dictionary<string, List<string>> dict, string category)
        {
            return dict[category][new Random().Next(dict[category].Capacity)];
        }
    }
    public enum GameState
    {
        Win,
        Lose,
        Ongoing
    }

}

