using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelProcessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик нажатия на кнопку "Выполнить"
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.Log("Начало обработки.");

                // Учитываем скрытые листы в зависимости от состояния чекбокса
                SettingsModule.IncludeHiddenSheets = !checkBox1.Checked;
                Logger.Log($"Скрытые листы: {(SettingsModule.IncludeHiddenSheets ? "учитываются" : "не учитываются")}");

                // Создаем папку для выходных файлов, если её нет
                SettingsModule.CreateOutputDirectory();
                Logger.Log($"Выходная папка: {SettingsModule.OutputDirectory}");

                // Получаем все Excel-файлы в указанной директории
                var excelFiles = Directory.GetFiles(SettingsModule.CurrentDirectory, "*.xlsx");
                Logger.Log($"Найдено файлов: {excelFiles.Length}");

                if (excelFiles.Length == 0)
                {
                    Logger.Log("Excel-файлы не найдены.");
                    MessageBox.Show("Excel-файлы не найдены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Обрабатываем каждый файл
                foreach (var file in excelFiles)
                {
                    Logger.Log($"Обработка файла: {file}");

                    // Читаем листы из файла
                    var sheets = ExcelModule.ReadSheets(file);
                    Logger.Log($"Найдено листов: {sheets.Count}");

                    // Анализируем и сортируем листы
                    var smetaSheets = new List<Excel.Worksheet>();
                    var aktSheets = new List<Excel.Worksheet>();

                    foreach (var sheet in sheets)
                    {
                        var text = sheet.UsedRange.Value2?.ToString() ?? string.Empty;
                        var type = TextAnalysisModule.DetermineDocumentType(text);

                        if (type == "Смета")
                            smetaSheets.Add(sheet);
                        else if (type == "Акт")
                            aktSheets.Add(sheet);
                    }

                    Logger.Log($"Найдено смет: {smetaSheets.Count}, актов: {aktSheets.Count}");

                    // Создаем выходные файлы
                    if (smetaSheets.Any())
                    {
                        var outputPath = Path.Combine(SettingsModule.OutputDirectory, $"ИтогСмет_{Path.GetFileNameWithoutExtension(file)}.xlsx");
                        ExcelModule.WriteSheets(outputPath, smetaSheets);
                        Logger.Log($"Создан файл: {outputPath}");
                    }

                    if (aktSheets.Any())
                    {
                        var outputPath = Path.Combine(SettingsModule.OutputDirectory, $"ИтогАкт_{Path.GetFileNameWithoutExtension(file)}.xlsx");
                        ExcelModule.WriteSheets(outputPath, aktSheets);
                        Logger.Log($"Создан файл: {outputPath}");
                    }
                }

                Logger.Log("Обработка завершена.");
                MessageBox.Show("Обработка завершена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Записываем ошибку в лог
                Logger.Log($"Ошибка: {ex.Message}\nПодробности: {ex.StackTrace}");
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик изменения состояния чекбокса
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Логика, если нужно что-то делать при изменении состояния чекбокса
            SettingsModule.IncludeHiddenSheets = !checkBox1.Checked;
        }

        // Обработчик нажатия на кнопку "Выбрать папку"
        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    SettingsModule.CurrentDirectory = folderDialog.SelectedPath;
                }
            }
        }

        // Обработчик клика на ProgressBar
        private void progressBar1_Click(object sender, EventArgs e)
        {
            // Пример: Показать текущее значение ProgressBar
            int currentValue = progressBar1.Value;
            MessageBox.Show($"Текущее значение ProgressBar: {currentValue}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Пример: Увеличить значение ProgressBar на 10 (если это имеет смысл в твоем проекте)
            if (progressBar1.Value + 10 <= progressBar1.Maximum)
            {
                progressBar1.Value += 10;
            }
            else
            {
                MessageBox.Show("Прогресс достиг максимума!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonTestProgressBar_Click(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                System.Threading.Thread.Sleep(50); // Задержка для имитации работы
            }
        }
    }
}