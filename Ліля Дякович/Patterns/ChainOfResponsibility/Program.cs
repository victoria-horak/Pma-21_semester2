namespace ChainOfRes
{
    class Program
    {
        static void Main(string[] args)
        {
            EnglishToFrenchTranslator englishToFrench = new EnglishToFrenchTranslator();
            FrenchToGermanTranslator frenchToGerman = new FrenchToGermanTranslator();
            UkrainToEnglishTranslator ukrainToEnglish = new UkrainToEnglishTranslator();
            englishToFrench.SetNext(frenchToGerman);
            frenchToGerman.SetNext(ukrainToEnglish);


            string fromLanguage = "French";
            string toLanguage = "German";
            string translatedText = englishToFrench.Translate(fromLanguage, toLanguage);
            System.Console.WriteLine(translatedText);
        }
    }
}
