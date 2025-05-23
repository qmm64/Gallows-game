using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallows_game
{
    internal class WordLoader
    {
        private List<string> _words;
        private string _path;

        public WordLoader() 
        {
            _path = "../../../../Files/Words.txt";
            _words = ParseWords(ReadFile(_path));
        }

        private string ReadFile(string path)
        {
            try
            {
                string text;
                using (StreamReader reader = new StreamReader(path))
                {
                    text = reader.ReadToEnd();
                }
                return text;
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Ошибка чтения файла. Текст ошибки: {ex.Message}");
                Environment.Exit(1);
                return null;
            }
        }

        private List<string> ParseWords(string text)
        {
            try
            {
                StringBuilder word = new StringBuilder();
                List<string> words = new List<string>();
                words = text.Split(", ").ToList();
                return words;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения слов из файла. Текст ошибки: {ex.Message}");
                Environment.Exit(1);
                return null;
            }
        }

        public string GetWord()
        {
            try
            {
                Random random = new Random();
                string word = _words[random.Next(_words.Count)];
                return word;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка получения случайного слова. Текст ошибки: {ex.Message}");
                Environment.Exit(1);
                return null;
            }
        }
    }
}
