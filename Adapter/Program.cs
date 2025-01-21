using System;

public class Adult
{
    private int age;

    public Adult(int age)
    {
        this.age = age;
    }

    public int GetAge()
    {
        return age;
    }
}
public class Validator
{
    public bool IsAdult(Adult person)
    {
        return person.GetAge() >= 18;
    }
}


public class FakeAdult : Adult
{
    private int realAge;

    public FakeAdult(int realAge) : base(21)
    {
        this.realAge = realAge;
    }


    public int GetRealAge()
    {
        return realAge;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Validator validator = new Validator();


        FakeAdult krzys = new FakeAdult(17);

        Console.WriteLine("Czy przeszedł walidację: " + validator.IsAdult(krzys));
        Console.WriteLine("Rzeczywisty wiek: " + krzys.GetRealAge());
    }
}