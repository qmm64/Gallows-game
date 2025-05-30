namespace Gallows_game
{
    internal class Program
    {
        public static void Main()
        {
            UI ui = new UI(); 
            List<string> categories = new List<string>() { "category1", "category2", "category2", "category4", "category5" };
            while (true)
            {
                ui.Logo();
                if (ui.PromptNewGame())
                {
                    Console.Clear();
                    // вывод категории
                    ui.DisplayCategories(categories);
                    // создание объекта игры ( ввод пользователя )
                    Game game = new Game(ui.PromptCategory(categories));

                    while (true)
                    {
                        var gameState = game.CheckGameState();
                        if (gameState == GameState.Ongoing)
                        {

                            Console.Clear();
                            // отрисовка виселицы принимает ошибки игрока
                            ui.DrawHangman(game.Errors);
                            // отображение угуданного слова в формате примерсл_ва
                            ui.DisplayWordProgress(game.GetCurrentProgress());
                            // отображение использованных букв
                            ui.DisplayGuessedLetters(game.GetGuessedLetters(),
                                game.GetWrongLetters(),
                                game.Word
                                );
                            // ввод вывод и проверка введенной буквы 
                            
                            string allUsedLetters = string.Concat(game.GetWrongLetters(), game.GetGuessedLetters());
                            HashSet<char> hash = new HashSet<char>();
                            
                            foreach (char c in allUsedLetters)
                                hash.Add(c);
                            game.CheckLetter(ui.IOInterface(hash));
                        }
                        else if (gameState == GameState.Win)
                        {
                            Console.Clear();
                            ui.DisplayWin(game.Word);
                            Console.ReadKey();
                            continue;
                        }
                        else if (gameState == GameState.Lose)
                        {
                            Console.Clear();
                            ui.DisplayLose(game.Word);
                            Console.ReadKey();
                            continue;
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
