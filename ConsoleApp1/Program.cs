using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите URL директории: ");
                string path = Console.ReadLine();

                Console.WriteLine($"Удалено {DeliteDerictories(path)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        static int DeliteDerictories(string path)
        {
            var accessTime = TimeSpan.FromMinutes(30);
            var countDelite = 0;
            var di = new DirectoryInfo(path);

            if (di.Exists)
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    TimeSpan time = DateTime.Now - file.LastAccessTime;
                    if (time.TotalMinutes > accessTime.Minutes)
                    {
                        Console.WriteLine($"Delite the {file}");
                        countDelite++;
                        file.Delete();
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Access to {file} was {time.TotalMinutes} minutes ago");
                    }
                }

                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    TimeSpan time = DateTime.Now - dir.LastAccessTime;
                    if (time.TotalMinutes > accessTime.Minutes)
                    {
                        Console.WriteLine($"Delite the {dir}");
                        Console.WriteLine();
                        dir.Delete(true);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Access to {dir} was {time.TotalMinutes} minutes ago");
                    }
                }
            }
            return countDelite;
        }
    }
}
