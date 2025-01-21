using System;

public interface IEmployee
{
    string Name { get; set; }
    string Position { get; set; }
    void Work();
    void AttendMeeting();
}

public class Employee : IEmployee
{
    public string Name { get; set; }
    public string Position { get; set; }

    public void Work()
    {
        Console.WriteLine($"{Name} pracuje.");
    }

    public void AttendMeeting()
    {
        Console.WriteLine($"{Name} uczestniczy w spotkaniu.");
    }
}

public class Manager : IEmployee
{
    public string Name { get; set; }
    public string Position { get; set; }

    public void Work()
    {
        Console.WriteLine($"{Name}, kierownik, pracuje nad strategią zespołu.");
    }

    public void AttendMeeting()
    {

        Console.WriteLine($"{Name}, kierownik, uczestniczy w spotkaniu zarządu.");
    }

    public void ManageTeam()
    {

        Console.WriteLine($"{Name} zarządza zespołem.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {

        IEmployee pracownik = new Employee
        {
            Name = "Jan Kowalski",
            Position = "Programista"
        };
        pracownik.Work();
        pracownik.AttendMeeting();


        Manager kierownik = new Manager
        {
            Name = "Anna Nowak",
            Position = "Kierownik Projektu"
        };
        kierownik.Work();
        kierownik.AttendMeeting();
        kierownik.ManageTeam();
    }
}