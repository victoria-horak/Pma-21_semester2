class FrenchToGermanTranslator : Translator
{
    public override string Translate( string fromLanguage, string toLanguage)
    {
        if (fromLanguage == "French" && toLanguage == "German")
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
            return "Die Übersetzung ist nicht möglich.";
        }
    }
}