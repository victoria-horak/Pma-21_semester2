using System;

namespace Mediator
{
    public class Program
    {
        public static void Main()
        {
            DeanOffice deanOffice = new DeanOffice();

            Teacher teacher = new Teacher(deanOffice);
            deanOffice.Teacher = teacher;

            Student student = new Student(deanOffice);
            deanOffice.Student = student;

            HR hr = new HR(deanOffice);
            deanOffice.HR = hr;

            Console.WriteLine("Event 1: BadWeather");
            teacher.Notify("BadWeather");
            student.Notify("BadWeather");

            Console.WriteLine("\nEvent 2: Epidemic");
            teacher.Notify("Epidemic");
            student.Notify("Epidemic");

            Console.WriteLine("\nEvent 3: EveryoneSick");
            teacher.Notify("EveryoneSick");
            student.Notify("EveryoneSick");
            hr.Notify("EveryoneSick");
        }

    }
}
