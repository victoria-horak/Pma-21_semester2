using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var Aduc = new Student { Aducation = new Aducation{ University = "Lnu", Course = 2 } };
            //var student1 = new Student { Name = "Lilia", Aducation = Aduc.DeepCopy() };
            //var student2 = new Student { Name = "Kolia", Aducation = Aduc.DeepCopy() };
            var student1 = Aduc.DeepCopy();
            var student2 = Aduc.DeepCopy();
            student1.Name = "Lilia";
            student2.Name = "Olex";
            student1.Aducation.Faculty = "Biology";
            student2.Aducation.Faculty = "MehMat";


            Console.WriteLine(student1);
            Console.WriteLine(student2);
        }
    }
}
