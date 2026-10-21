using System;
using System.Collections.Generic;
using System.Globalization;

namespace GeoInterface
{
    class Program
    {
        static List<IGeographicObject> objects = new List<IGeographicObject>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            // Початкові дані
            objects.Add(new River(30.5, 50.4, "Дніпро", "Найбільша річка України", 50, 2201));
            objects.Add(new Mountain(24.5, 48.16, "Говерла", "Найвища гора України", 2061));

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n===== ГЕОГРАФІЧНІ ОБ'ЄКТИ (інтерфейс) =====");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1 - Додати річку");
                Console.WriteLine("2 - Додати гору");
                Console.WriteLine("3 - Показати всі об'єкти");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();
                if (choice == null) break;

                if (string.IsNullOrWhiteSpace(choice))
                {
                    PrintError("Ви нічого не ввели. Оберіть пункт від 0 до 3.");
                    continue;
                }

                try
                {
                    switch (choice.Trim())
                    {
                        case "1": AddRiver(); break;
                        case "2": AddMountain(); break;
                        case "3": ShowAll(); break;
                        case "0": Console.ResetColor(); return;
                        default: PrintError("Невірний пункт меню. Оберіть число від 0 до 3."); break;
                    }
                }
                catch (ArgumentException ex)
                {
                    PrintError(ex.Message);
                }
            }
            Console.ResetColor();
        }

        static void AddRiver()
        {
            string name = ReadText("Назва: ");
            string desc = ReadText("Опис: ");
            double x = ReadDouble("Координата X (-180..180): ", -180, 180);
            double y = ReadDouble("Координата Y (-90..90): ", -90, 90);
            double speed = ReadDouble("Швидкість течії, см/с: ", 0.01, 1000);
            double length = ReadDouble("Загальна довжина, км: ", 0.01, 10000);

            objects.Add(new River(x, y, name, desc, speed, length));
            Console.WriteLine($"Річку \"{name}\" додано.");
        }

        static void AddMountain()
        {
            string name = ReadText("Назва: ");
            string desc = ReadText("Опис: ");
            double x = ReadDouble("Координата X (-180..180): ", -180, 180);
            double y = ReadDouble("Координата Y (-90..90): ", -90, 90);
            double height = ReadDouble("Найвища точка, м: ", 1, 9000);

            objects.Add(new Mountain(x, y, name, desc, height));
            Console.WriteLine($"Гору \"{name}\" додано.");
        }

        static void ShowAll()
        {
            if (objects.Count == 0)
            {
                Console.WriteLine("Список порожній.");
                return;
            }
            foreach (IGeographicObject obj in objects)
            {
                Console.WriteLine("\n" + obj.GetInfo());
                Console.WriteLine("--------------------");
            }
        }

        static string ReadText(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (input == null) { Console.ResetColor(); Environment.Exit(0); }

                if (string.IsNullOrWhiteSpace(input))
                {
                    PrintError("Ви нічого не ввели. Введіть текст.");
                    continue;
                }
                if (input.Trim().Length > 200)
                {
                    PrintError("Занадто довгий текст (максимум 200 символів).");
                    continue;
                }
                return input.Trim();
            }
        }

        static double ReadDouble(string prompt, double min, double max)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (input == null) { Console.ResetColor(); Environment.Exit(0); }

                if (string.IsNullOrWhiteSpace(input))
                {
                    PrintError("Ви нічого не ввели. Введіть число.");
                    continue;
                }

                input = input.Trim().Replace(',', '.');
                if (!double.TryParse(input,
                        NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint,
                        CultureInfo.InvariantCulture, out double value)
                    || double.IsNaN(value) || double.IsInfinity(value))
                {
                    PrintError("Це не число. Приклад: 48.16");
                    continue;
                }

                if (value < min || value > max)
                {
                    PrintError($"Число має бути від {min} до {max}.");
                    continue;
                }
                return value;
            }
        }

        static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Помилка: " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}