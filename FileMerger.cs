using System;
using System.IO;

namespace B1_task1;
class FileMerger
{
    public static void MergeFiles(string filesDirectoryPath, string outputPath, string filter)
    {
        int removedLinesCount = 0;
        //получение папки со сгенерированными файлами
        DirectoryInfo dir = new(filesDirectoryPath);
        using (StreamWriter writer = new(outputPath))
        {
            foreach (var filePath in dir.GetFiles())
            {
                using (StreamReader reader = new(filePath.FullName))
                {
                    string line;
                    while ((line = reader.ReadLine()!) != null)
                    {
                        //проверка на вход в строку введенное подстроки-фильтра
                        if (!line.Contains(filter))
                        {
                            writer.WriteLine(line);
                        }
                        else
                        {
                            removedLinesCount++;
                        }
                    }
                }
            }
        }
        //вывод информации о количестве строк, не вошедших в файл из-за фильтра
        Console.WriteLine($"Удалено строк: {removedLinesCount}");
    }
}