
public interface IEmployee
{
    void Work();
    void AttendMeeting();
}


public class Employee : IEmployee
{
    public string Name { get; set; }
    public string Position { get; set; }

    public void Work()
    {
        /* Implementacja */
    }

    public void AttendMeeting()
    {
        /* Implementacja */
    }
}


public class Manager : IEmployee
{
    public string Name { get; set; }
    public string Position { get; set; }

  
    public void Work()
    {
        /* Implementacja dla managera */
    }

    public void AttendMeeting()
    {
        /* Implementacja dla managera */
    }

    public void ManageTeam()
    {
        /* Implementacja */
    }
}


class Program
{
    static void Main(string[] args)
    {
        IEmployee employee = new Employee();
        employee.Work();
        employee.AttendMeeting();

        Manager manager = new Manager();
        manager.Work();
        manager.AttendMeeting();
        manager.ManageTeam();
    }
}