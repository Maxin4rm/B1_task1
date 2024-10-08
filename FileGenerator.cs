using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B1_task1
{
    public static class FileGenerator
    {
        public static void GenerateFiles(string pathToDirectory)
        {
            //генерация файлов
            Random random = new();
            for (int i = 0; i < 100; i++)
            {
                using (StreamWriter writer = new($"{pathToDirectory}\\file_{i}.txt"))
                {
                    for (int j = 0; j < 100000; j++)
                    {
                        string randomDate = GenerateRandomDate(random);
                        string randomLatin = GenerateRandomLatinString(random, 10);
                        string randomCyrillic = GenerateRandomCyrillicString(random, 10);
                        int randomEvenNumber = GenerateRandomEvenNumber(random, 1, 100000000);
                        double randomDouble = Math.Round(random.NextDouble() * 19 + 1, 8);

                        writer.WriteLine($"{randomDate}||{randomLatin}||{randomCyrillic}||{randomEvenNumber}||{randomDouble}||");
                    }
                }
            }
        }

        static string GenerateRandomDate(Random random)
        {
            //генерация случайной за последние 5 лет
            DateTime start = DateTime.Now.AddYears(-5);
            DateTime end = DateTime.Now;
            TimeSpan range = end - start;
            DateTime randomDate = start.AddDays(random.Next((int)range.TotalDays));
            return randomDate.ToString("dd.MM.yyyy");
        }

        static string GenerateRandomLatinString(Random random, int length)
        {
            //генерация случайного набора из 10 латинских символов 
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static string GenerateRandomCyrillicString(Random random, int length)
        {
            //генерация случайного набора из 10 русских символов 
            const string chars = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдежзийклмнопрстуфхцчшщъыьэюя";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static int GenerateRandomEvenNumber(Random random, int min, int max)
        {
            //генерация случайного положительного четного целочисленного числа в диапазоне от min до max
            int number;
            do
            {
                number = random.Next(min, max);
            } while (number % 2 != 0);
            return number;
        }
    }
}
