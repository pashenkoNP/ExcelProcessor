using System;
using System.IO;

namespace ExcelProcessor
{
    public static class Logger
    {
        private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");

        public static void Log(string message)
        {
            try
            {
                string logMessage = $"{DateTime.Now}: {message}";
                File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Если не удалось записать в лог, выводим ошибку в консоль
                Console.WriteLine($"Ошибка при записи в лог: {ex.Message}");
            }
        }
    }
}