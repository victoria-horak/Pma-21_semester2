class EnglishToFrenchTranslator : Translator
{
    public override string Translate(string fromLanguage, string toLanguage)
    {
        if (fromLanguage == "English" && toLanguage == "French")
        {
            return this + " can translate";
        }
        else if (next != null)
        {
            System.Console.WriteLine(this + " cannot translate this text");
            return next.Translate(fromLanguage, toLanguage);
        }
        else
        {
            return "La traduction n'est pas possible.";
        }
    }
}
