using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfRes
{
    class UkrainToEnglishTranslator : Translator
    {
        public override string Translate( string fromLanguage, string toLanguage)
        {
            if (fromLanguage == "Ukrain" && toLanguage == "English")
            {
                return this + " can translate";
            }
            else if (next != null)
            {
                System.Console.WriteLine(this + " cannot translate this text");
                return next.Translate( fromLanguage, toLanguage);
            }
            else
            {
                return "Cant translate.";
            }
        }
    }
}
