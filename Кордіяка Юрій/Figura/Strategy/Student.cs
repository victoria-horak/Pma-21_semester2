using System;

namespace StrategyProgrammingLanguage
{
    public class Student
    {
        private string Name;
        private IProgrammingLanguage programmingLanguage;
        
        public Student(string Name)
        {
            this.Name = Name;
        }

        public void SetLanguage(IProgrammingLanguage programmingLanguage)
        {
            this.programmingLanguage = programmingLanguage;
        }

        public void Learn()
        {
            if (this.programmingLanguage == null)
            {
                Console.WriteLine("I haven't chosen a programming language yet");
            }
            else
            {
                Console.Write(this.Name + " chose ");
                programmingLanguage.Study();
            }
            
          
        }
    }
}