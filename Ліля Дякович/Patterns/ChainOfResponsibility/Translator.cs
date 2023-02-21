abstract class Translator
{
    protected Translator next;

    public void SetNext(Translator translator)
    {
        next = translator;
    }

    public abstract string Translate(string fromLanguage, string toLanguage);
}
