using System;
using System.IO;

namespace B1_task1;
class FileMerger
{
    public static void MergeFiles(string filesDirectoryPath, string outputPath, string filter)
    {
        int removedLinesCount = 0;
        DirectoryInfo dir = new(filesDirectoryPath);
        using (StreamWriter writer = new(outputPath))
        {
            foreach (var filePath in dir.GetFiles())
            {
                using (StreamReader reader = new(filePath.FullName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
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

        Console.WriteLine($"Удалено строк: {removedLinesCount}");
    }
}