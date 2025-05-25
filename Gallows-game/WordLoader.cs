
namespace Gallows_game
{
    internal class WordLoader
    {
        private readonly Dictionary<string, List<string>> _words;
        private readonly string _path;

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
                using (StreamReader reader = new(path))
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

        private Dictionary<string, List<string>> ParseWords(string text)
        {
            try
            {
                Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();
                List<string> wordsWithCategories = text.Split("\n").ToList();
                foreach (var elements in wordsWithCategories)
                {
                    var wordsWithCategory = elements.Split([", ", ": ","\r"],StringSplitOptions.RemoveEmptyEntries).ToList();
                    string category = wordsWithCategory[0];
                    wordsWithCategory.Remove(category);
                    words.Add(category,wordsWithCategory);
                }
                return words;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения слов из файла. Текст ошибки: {ex.Message}");
                Environment.Exit(1);
                return null;
            }
        }

        public List<string> GetCategories()
        {
            try
            {
                var categories = new List<string>();
                foreach (var category in _words)
                {
                    categories.Add(category.Key);
                }
                return categories;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка получения категории. Текст ошибки: {ex.Message}");
                Environment.Exit(1);
                return null;
            }
        }

        public string GetWord(string category)
        {
            try
            {
                _words.TryGetValue(category, out List<string> words);
                Random random = new Random();
                string word = words[random.Next(words.Count)];
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
