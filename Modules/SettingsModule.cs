using System;
using System.IO;

namespace ExcelProcessor
{
    public static class SettingsModule
    {
        // Текущая директория, где находятся входные файлы
        public static string CurrentDirectory { get; set; } = @"D:\Проекты в Си шарп\ExcelProcessor\Тестовые Файлы";

        // Директория для выходных файлов
        public static string OutputDirectory => Path.Combine(CurrentDirectory, "Output");

        // Учитывать скрытые листы (по умолчанию false)
        public static bool IncludeHiddenSheets { get; set; } = false;

        // Создать папку для выходных файлов, если её нет
        public static void CreateOutputDirectory()
        {
            if (!Directory.Exists(OutputDirectory))
            {
                Directory.CreateDirectory(OutputDirectory);
            }
        }
    }
}