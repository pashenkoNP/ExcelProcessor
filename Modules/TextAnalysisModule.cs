namespace ExcelProcessor
{
    public static class TextAnalysisModule
    {
        // Определение типа документа (Смета или Акт)
        public static string DetermineDocumentType(string text)
        {
            foreach (var phrase in ConstantsModule.KeyPhrases["Смета"])
            {
                if (text.Contains(phrase))
                    return "Смета";
            }

            foreach (var phrase in ConstantsModule.KeyPhrases["Акт"])
            {
                if (text.Contains(phrase))
                    return "Акт";
            }

            return "Неизвестно";
        }

        // Определение разновидности документа (БИМ, РИМ, РМ)
        public static string DetermineVariety(string text)
        {
            foreach (var variety in ConstantsModule.KeyPhrases.Keys)
            {
                if (variety == "Смета" || variety == "Акт")
                    continue;

                foreach (var phrase in ConstantsModule.KeyPhrases[variety])
                {
                    if (text.Contains(phrase))
                        return variety;
                }
            }

            return "Неизвестно";
        }
    }
}