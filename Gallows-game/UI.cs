using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallows_game
{
    public class UI
    {
        private readonly string[] hangmanStages = new string[]
         {
        // 0 ошибок
                @"
          +---+
          |   |
              |
              |
              |
              |
        =========",
                // 1 ошибка
                @"
          +---+
          |   |
          O   |
              |
              |
              |
        =========",
                // 2 ошибки
                @"
          +---+
          |   |
          O   |
          |   |
              |
              |
        =========",
                // 3 ошибки
                @"
          +---+
          |   |
          O   |
         /|   |
              |
              |
        =========",
                // 4 ошибки
                @"
          +---+
          |   |
          O   |
         /|\  |
              |
              |
        =========",
                // 5 ошибок
                @"
          +---+
          |   |
          O   |
         /|\  |
         /    |
              |
        =========",
                // 6 ошибок - проигрыш
                @"
          +---+
          |   |
          O   |
         /|\  |
         / \  |
              |
        ========="
        };

        // вывод подвешанного челика
        public void DrawHangman(int errors)
        {
            if (errors < 0) errors = 0;
            if (errors >= hangmanStages.Length) errors = hangmanStages.Length - 1;

            Console.WriteLine(hangmanStages[errors]);
        }
        // отображение угаданного слова
        public void DisplayWordProgress(string progress)
        {
            Console.WriteLine("Слово: " + progress);
        }

        // отображение введенных букв
        public void DisplayGuessedLetters(IEnumerable<char> correct, IEnumerable<char> wrong, string category)
        {
            Console.WriteLine("Тема: " + category);
            Console.WriteLine("Угаданные буквы: " + string.Join(" ", correct));
            Console.WriteLine("Ошибочные буквы: " + string.Join(" ", wrong));
        }

        // ввод вывод
        public char IOInterface(HashSet<char> usedLetters)
        {
            while (true)
            {
                Console.Write("Введите букву: ");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) && input.Length != 1)
                {
                    Console.WriteLine("Введите одну букву.");
                    continue;
                }

                char letter = char.ToUpper(input[0]);

                if (!char.IsLetter(letter))
                {
                    Console.WriteLine("Введите букву алфавита.");
                    continue;
                }

                if (usedLetters.Contains(letter))
                {
                    Console.WriteLine("Эта буква уже была введена. Попробуйте другую.");
                    continue;
                }

                return letter;
            }
        }

        public void DisplayWin(string word)
        {
            Console.WriteLine($"Поздравляем! Вы угадали слово: {word}");
        }

        public void DisplayLose(string word)
        {
            Console.WriteLine($"Вы проиграли. Загаданное слово: {word}");
        }

        // типо менюшка
        public bool PromptNewGame()
        {
            Console.Write("Начать новую игру? (д/н): ");
            while (true)
            {
                var input = Console.ReadLine().Trim().ToLower();
                if (input == "д" || input == "y" || input == "yes")
                return true;
            else if (input == "н" || input == "n" || input == "no")
                return false;
            else
                    Console.Write("Введите 'д' или 'н': ");
            }
        }

        // отображение категорий
        public void DisplayCategories(IEnumerable<string> categories) 
        {
            Console.WriteLine("Доступные категории:");
            int i = 1;
            foreach (var cat in categories)
            {
                Console.WriteLine($"{i}. {cat}");
                i++;
            }
        }

        // ввод категории
        public string PromptCategory(IEnumerable<string> categories) // выбор категории
        {
            Console.WriteLine("Выберите категорию по номеру или нажмите Enter для случайной категории:");
            var cats = categories.ToList();

            while (true)
            {
                Console.Write("Категория: ");
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    return null;

                if (int.TryParse(input, out int num) && num >= 1 && num <= cats.Count)
                    return cats[num - 1];

                Console.WriteLine("Некорректный ввод. Попробуйте ещё раз.");
            }
        }

        public void Logo()
        {
            Console.WriteLine(
                        @"
                THE IGRA 
                ВИСЕЛИЦА

                  +---+
                  |   |
                  O   |
                 /|\  |
                 / \  |
                      |
                =========" + "\n\n"
            );
        }
    }
}

