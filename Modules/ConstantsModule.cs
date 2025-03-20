/*
 Этот файл содержит словари ключевых слов и фраз,
используемых для поиска ключевых фраз в тексте.
 */
using System.Collections.Generic;

namespace ExcelProcessor
{
    public static class ConstantsModule
    {
        // Фразы для определения статуса документа
        public static readonly Dictionary<int, string[]> PHRASA_StatusSmet = new Dictionary<int, string[]>
        {
            { 1, new[] { "всего по смете" } }  // Статус = 1 (Смета)
        };

        public static readonly Dictionary<int, string[]> PHRASA_StatusAkt = new Dictionary<int, string[]>
        {
            { 2, new[] { "всего по акту" } }    // Статус = 2 (Акт)
        };

        // Фразы для определения категории документа
        public static readonly Dictionary<int, string[]> PHRASA_KatSmet = new Dictionary<int, string[]>
        {
            { 1, new[] { "базисно-индексным" } },  // ЛСР, БИМ (12 п.), Приложение №2 МинСтроя
            { 2, new[] { "ресурсно-индексным" } },  // ЛСР, РИМ (12 п.), Приложение №3 МинСтроя
            { 3, new[] { "ресурсным" } }            // ЛСР, РМ (10 п.), Приложение №4 МинСтроя
        };

        public static readonly Dictionary<int, string[]> PHRASA_KatAkt = new Dictionary<int, string[]>
        {
            { 1, new[] { "позиции по смете", "Сметная стоимость в базисном уровне цен" } },
            { 2, new[] { "позиции по смете", "Сметная стоимость," } },
            { 3, new[] { "позиции по смете", "всего" } }
        };

        public static readonly Dictionary<int, string[]> PHRASA_KatDopAkt = new Dictionary<int, string[]>
        {
            { 1, new[] { "позиции по смете" } }  // Если есть, добавляется 1 столбец
        };

        // Фразы для БИМ, РИМ, РМ
        public static readonly Dictionary<int, string[]> PHRASA_BIM = new Dictionary<int, string[]>
        {
            { 1, new[] { "Количество", "Сметная стоимость в базисном уровне цен", "Индексы" } }
        };

        public static readonly Dictionary<int, string[]> PHRASA_RIM = new Dictionary<int, string[]>
        {
            { 1, new[] { "Количество", "Сметная стоимость,", "всего в текущем уровне цен" } }
        };

        public static readonly Dictionary<int, string[]> PHRASA_RM = new Dictionary<int, string[]>
        {
            { 1, new[] { "Количество", "Сметная стоимость в текущем уровне цен", "всего" } }
        };

        // Фразы для смет (LSR)
        public static readonly Dictionary<int, string[]> PHRASA_LSR = new Dictionary<int, string[]>
        {
            { 1, new[] { "(наименование стройки)" } },
            { 2, new[] { "(наименование объекта капитального строительства)" } },
            { 3, new[] { "локальный сметный" } },
            { 4, new[] { "(наименование работ и затрат)" } },
            { 5, new[] { "основание" } },
            { 6, new[] { "Составлен(а) в текущем" } },
            { 7, new[] { "Сметная стоимость" } },
            { 8, new[] { "строительных работ" } },
            { 9, new[] { "монтажных работ" } },
            { 10, new[] { "оборудования" } },
            { 11, new[] { "прочих затрат" } },
            { 12, new[] { "на оплату труда рабочих" } },
            { 13, new[] { "на оплату труда машинистов" } },
            { 14, new[] { "затраты труда рабочих" } },
            { 15, new[] { "затраты труда машинистов" } },
            { 16, new[] { "ВСЕГО по смете" } }
        };

        // Фразы для актов (AKT)
        public static readonly Dictionary<int, string[]> PHRASA_AKT = new Dictionary<int, string[]>
        {
            { 1, new[] { "Подрядчик (Субподрядчик)" } },
            { 2, new[] { "Стройка" } },
            { 3, new[] { "Объект" } },
            { 4, new[] { "Акт" } },
            { 5, new[] { "Сметная (договорная) стоимость" } },
            { 6, new[] { "Средства на оплату труда" } },
            { 7, new[] { "Сметная трудоемкость" } }
        };
    }
}

/*
 Описание изменений:  (было - KeyPhrases )
Словари для статусов документа:

PHRASA_StatusSmet и PHRASA_StatusAkt преобразованы в Dictionary<int, string[]>.

Словари для категорий документа:

Все словари, такие как PHRASA_KatSmet, PHRASA_KatAkt, PHRASA_KatDopAkt, PHRASA_BIM, PHRASA_RIM, PHRASA_RM, PHRASA_LSR, и PHRASA_AKT, преобразованы в Dictionary<int, string[]>.

Организация кода:

Все словари объявлены как статические поля класса ConstantsModule, что позволяет использовать их без создания экземпляра класса.

Этот код теперь соответствует требованиям и может быть использован в C# проекте для работы с ключевыми фразами и категориями документов.
 */