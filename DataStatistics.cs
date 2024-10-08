using Npgsql;

namespace B1_task1;

public static class DataStatistics
{
    public static void CalculateSumOfIntsAndMedianOfFloats(string tableName, string intColumn, string floatColumn, string connectionString)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            // SQL-запрос для вычисления суммы и медианы
            string sql = $@"
            SELECT 
                SUM({intColumn}) AS TotalSum, 
                PERCENTILE_CONT(0.5) WITHIN GROUP (ORDER BY {floatColumn}) AS MedianValue
            FROM {tableName};";

            using (var cmd = new NpgsqlCommand(sql, connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        long totalSum = reader.IsDBNull(0) ? 0 : reader.GetInt64(0);
                        double medianValue = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                        // Вывод результатов
                        Console.WriteLine($"Сумма: {totalSum}, Медиана: {medianValue}");
                    }
                }
            }
        }
    }
}
