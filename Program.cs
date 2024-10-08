using B1_task1;

class Program
{
    const string connectionString = "Server=localhost;Port=5432;Database=b1_task1;Username=postgres;Password=postgres;";
    // Имя таблицы
    const string tableName = "\"FileDataTable\"";
    // Имя столбца с целыми числами
    const string intColumn = "\"EvenNumber\"";
    // Имя столбца с вещественными числами
    const string floatColumn = "\"FloatNumber\"";
    //путь к папку со сгенерированными файлами
    const string pathToDirectory = "files";
    //путь к файлу для задания 1(объединение файлов)
    const string pathToOutputFile = "output.txt";
    const string baseOutput = "Введите '1' чтобы выполнить задание 1,\n введите '2' для выполнения задания 2," +
        "\n введите '3' для выполнения задания 3,\n введите '4' чтобы выйти";
    //текст задания
    const string task = "Задание 1. Реализовать объединение файлов в один. При объединении должна быть" +
        " возможность удалить из всех файлов строки с заданным сочетанием символов, например, «abc» с выводом" +
        " информации о количестве удаленных строк \nЗадание 2. Создать процедуру импорта файлов с таким набором" +
        " полей в таблицу в СУБД. При импорте должен выводится ход процесса (сколько строк импортировано, сколько осталось)" +
        " \nЗадание 3. Реализовать хранимую процедуру в БД (или скрипт с внешним sql-запросом), который считает сумму всех целых" +
        " чисел и медиану всех дробных чисел";
    
    static void Main()
    {
        int input = 0;
        //создание папки для вывода сгенерированных файлов  
        Directory.CreateDirectory(pathToDirectory);
        Console.WriteLine("Генерация файлов...");
        //генерация файлов
        FileGenerator.GenerateFiles(pathToDirectory);

        Console.WriteLine(task);
        do
        {
            Console.WriteLine(baseOutput);
            try
            {
                input = Int32.Parse(Console.ReadLine()!);
            }
            catch
            {
                Console.WriteLine("Некорректныый ввод");
            }
            switch (input)
            {
                case 1:
                    //выполнение объединения файлов (задание 1)
                    Console.WriteLine("Введите строку");
                    string? inputString = Console.ReadLine();
                    FileMerger.MergeFiles(pathToDirectory, pathToOutputFile, inputString is null ? "" : inputString);
                    break;
                case 2:
                    //импорт данных файла в СУБД (задание 2)
                    Console.WriteLine("Введите путь к файлу");
                    string? pathToFile = Console.ReadLine();
                    if (pathToFile is null)
                    {
                        Console.WriteLine("Некорректный ввод");
                        break;
                    }
                    DataImporter.ImportFilesToDb(pathToFile);
                    break;
                case 3:
                    //вычисление суммы и медианы (задание 3)
                    DataStatistics.CalculateSumOfIntsAndMedianOfFloats(tableName, intColumn, floatColumn, connectionString);
                    break;
                case 4:
                    //выход из программы
                    break;
                default: 
                    Console.WriteLine("Некорректныый ввод");
                    break;
            }
        } while (input != 4);  
    }
}