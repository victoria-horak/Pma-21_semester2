using System;

// The Mediator interface defines a method for communicating between colleagues.
public interface IMediator
{
    void Notify(object sender, string eventName);
}

// The Concrete Mediator implements the Mediator interface and coordinates communication between colleagues.
public class DeanOffice : IMediator
{
    private Teacher _teacher;
    private Student _student;
    private HR _hr;

    public Teacher Teacher
    {
        set { _teacher = value; }
    }

    public Student Student
    {
        set { _student = value; }
    }

    public HR HR
    {
        set { _hr = value; }
    }

    public void Notify(object sender, string eventName)
    {
        switch (eventName)
        {
            case "BadWeather":
                Console.WriteLine("Dean's office receives notification of bad weather...");
                _teacher.LateForClass();
                _student.LateForClass();
                break;

            case "Epidemic":
                Console.WriteLine("Dean's office receives notification of an epidemic...");
                _teacher.LateForClass();
                _student.LateForClass();
                _student.GetSick();
                break;

            case "EveryoneSick":
                Console.WriteLine("Dean's office receives notification that everyone is sick...");
                _teacher.AbsentFromClass();
                _student.AbsentFromClass();
                _hr.AbsentFromWork();
                break;

            default:
                Console.WriteLine($"Dean's office received unknown event: {eventName}");
                break;
        }
    }
}

// The Colleague class defines a method for notifying the Mediator of an event.
public abstract class Colleague
{
    protected IMediator _mediator;

    public Colleague(IMediator mediator)
    {
        _mediator = mediator;
    }

    public abstract void Notify(string eventName);
}

// The Concrete Colleague classes implement the Colleague interface and interact with the Mediator to handle events.
public class Teacher : Colleague
{
    public Teacher(IMediator mediator) : base(mediator) { }

    public void LateForClass()
    {
        Console.WriteLine("Teacher is late for class.");
    }

    public void AbsentFromClass()
    {
        Console.WriteLine("Teacher is absent from class.");
    }

    public override void Notify(string eventName)
    {
        _mediator.Notify(this, eventName);
    }
}

public class Student : Colleague
{
    public Student(IMediator mediator) : base(mediator) { }

    public void LateForClass()
    {
        Console.WriteLine("Student is late for class.");
    }

    public void GetSick()
    {
        Console.WriteLine("Student is sick.");
    }

    public void AbsentFromClass()
    {
        Console.WriteLine("Student is absent from class.");
    }

    public override void Notify(string eventName)
    {
        _mediator.Notify(this, eventName);
    }
}

public class HR : Colleague
{
    public HR(IMediator mediator) : base(mediator) { }

    public void AbsentFromWork()
    {
        Console.WriteLine("HR is absent from work.");
    }

    public override void Notify(string eventName)
    {
        _mediator.Notify(this, eventName);
    }
}

// The Client creates the Mediator and Colleague objects, and interacts with the Colleagues to trigger events.
//public class Program
//{
//    public static void Main()
//    {
//        DeanOffice deanOffice = new DeanOffice();

//        Teacher teacher = new Teacher(deanOffice);
//        deanOffice.Teacher = teacher;

//        Student student = new Student(deanOffice);
//        deanOffice.Student = student;

//        HR hr = new HR(deanOffice);
//        deanOffice.HR = hr;

//        Console.WriteLine("Event 1: BadWeather");
//        teacher.Notify("BadWeather");
//        student.Notify("BadWeather");

//        Console.WriteLine("\nEvent 2: Epidemic");
//        teacher.Notify("Epidemic");
//        student.Notify("Epidemic");

//        Console.WriteLine("\nEvent 3: EveryoneSick");
//        teacher.Notify("EveryoneSick");
//        student.Notify("EveryoneSick");
//        hr.Notify("EveryoneSick");
//    }
//}