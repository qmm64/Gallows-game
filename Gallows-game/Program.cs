namespace Gallows_game
{
    internal class Program
    {
        public static void Main()
        {
            UI ui = new UI(); 
            List<string> categories = new List<string>() { "categoryfirst", "categorysec", "categorythird", "categoryfourth", "categoryfifth" };
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>(); // <категория, набор слов>
            while (true)
            {
                Console.Clear();
                ui.Logo();
                if (ui.PromptNewGame())
                {
                    Console.Clear();
                    // вывод категории
                    ui.DisplayCategories(categories);
                    // создание объекта игры ( ввод пользователя )
                    Game game = new Game(dict, ui.PromptCategory(dict.Keys));

                    while (true)
                    {
                        var gameState = game.CheckGameState();
                        if (gameState == GameState.Ongoing)
                        {

                            Console.Clear();
                            // отрисовка виселицы принимает ошибки игрока
                            ui.DrawHangman(game.Errors);
                            // отображение угаданного слова в формате "примерсл_ва"
                            ui.DisplayWordProgress(game.GetCurrentProgress());
                            // отображение использованных букв(неправельные_ответы, загаданное_слово)
                            ui.DisplayGuessedLetters(game.GetGuessedLetters(),
                                game.GetWrongLetters(),
                                game.Word
                                );

                            // ввод вывод и проверка введенной буквы 
                            
                            HashSet<char> allUsedLetters = new HashSet<char>(game.GetWrongLetters()); // поле для объединения всех использованных букв
                            allUsedLetters.UnionWith(game.GetGuessedLetters()); // объединение всех букв в один сет
                            game.CheckLetter(ui.IOInterface(allUsedLetters)); // запуск интерфейса ввода\вывода, определение буквы на наличие в слове или в использованных наборах
                        }
                        else if (gameState == GameState.Win)
                        {
                            Console.Clear();
                            ui.DisplayWin(game.Word);
                            ui.DrawHangman(game.Errors);
                            Console.ReadKey();
                            break;
                        }
                        else if (gameState == GameState.Lose)
                        {
                            Console.Clear();
                            ui.DisplayLose(game.Word);
                            ui.DrawHangman(game.Errors);
                            Console.ReadKey();
                            break;
                        }
                    }
                }
                else {
                    Console.WriteLine("Выкл");
                    break; }
            }
        }
    }
}
