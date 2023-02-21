namespace StrategyProgrammingLanguage
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Student student = new Student("Ivan");
            student.Learn();
            student.SetLanguage(new Java());
            student.Learn();
            student.SetLanguage(new Python());
            student.Learn();
        }
    }
}