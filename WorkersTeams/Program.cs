using System;
using System.Collections.Generic;

namespace WorkersTeams
{
    class Program
    {
        static List<Team> teams = new List<Team>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Рожеве оформлення
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n===== МЕНЮ =====");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("1 - Створити команду");
                Console.WriteLine("2 - Додати співробітника в команду");
                Console.WriteLine("3 - Інформація про команду");
                Console.WriteLine("4 - Детальна інформація про команду");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                switch (Console.ReadLine())
                {
                    case "1": CreateTeam(); break;
                    case "2": AddWorkerToTeam(); break;
                    case "3": ShowTeam(false); break;
                    case "4": ShowTeam(true); break;
                    case "0":
                        Console.ResetColor();
                        return;
                    default: Console.WriteLine("Невірний вибір!"); break;
                }
            }
        }

        static void CreateTeam()
        {
            Console.Write("Введіть назву команди: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Назва не може бути порожньою.");
                return;
            }
            teams.Add(new Team(name));
            Console.WriteLine($"Команду \"{name}\" створено.");
        }

        static Team ChooseTeam()
        {
            if (teams.Count == 0)
            {
                Console.WriteLine("Спочатку створіть команду!");
                return null;
            }

            Console.WriteLine("Оберіть команду:");
            for (int i = 0; i < teams.Count; i++)
                Console.WriteLine($"{i + 1} - {teams[i].Name}");
            Console.Write("Номер: ");

            if (int.TryParse(Console.ReadLine(), out int index)
                && index >= 1 && index <= teams.Count)
                return teams[index - 1];

            Console.WriteLine("Невірний номер команди.");
            return null;
        }

        static void AddWorkerToTeam()
        {
            Team team = ChooseTeam();
            if (team == null) return;

            Console.Write("Введіть ПІБ співробітника: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ім'я не може бути порожнім.");
                return;
            }

            Console.WriteLine("Оберіть посаду: 1 - Розробник, 2 - Менеджер");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            Worker worker;
            if (choice == "1") worker = new Developer(name);
            else if (choice == "2") worker = new Manager(name);
            else
            {
                Console.WriteLine("Невірна посада.");
                return;
            }

            worker.FillWorkDay();
            team.AddWorker(worker);
            Console.WriteLine($"{worker.Position} {name} доданий(а) до команди \"{team.Name}\".");
        }

        static void ShowTeam(bool detailed)
        {
            Team team = ChooseTeam();
            if (team == null) return;

            Console.WriteLine();
            if (detailed) team.PrintDetailedInfo();
            else team.PrintInfo();
        }
    }
}