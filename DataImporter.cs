using System.Globalization;

namespace B1_task1;

public static class DataImporter
{
    public async static void ImportFilesToDb(string path)
    {
        using (var context = new ApplicationDbContext())
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Указан неверный путь к файлу");
                return;
            }
            var lines = File.ReadAllLines(path);
            int totalLines = lines.Length;
            int insertedLines = 0;
            var tasks = new List<Task>();
            foreach (var line in lines)
            {
                var parts = line.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 5) continue; // Пропуск строки, если некорректное количество данных

                try
                {
                    var fileData = new FileDataTable
                    {
                        Date = DateTime.ParseExact(parts[0], "dd.MM.yyyy", CultureInfo.InvariantCulture).ToUniversalTime(),
                        LatinString = parts[1],
                        RussianString = parts[2],
                        EvenNumber = int.Parse(parts[3]),
                        FloatNumber = float.Parse(parts[4].Replace(',', '.'), CultureInfo.InvariantCulture)
                    };
                    context.FileDataTable.Add(fileData);
                    insertedLines++;
                    Console.WriteLine($"Импортировано {insertedLines} из {totalLines} строк. Осталось {totalLines - insertedLines}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка вставки: {e.Message}");
                }
            }
            // Сохранение изменений в базе данных
            await context.SaveChangesAsync();
        }
    }
}