using System;


public class Car
{
    public Engine GetEngine()
    {
        return new Engine();
    }

    
    public string GetCylinderSize()
    {
        return GetEngine().GetCylinder().GetSize();
    }
}

public class Engine
{
    public Cylinder GetCylinder()
    {
        return new Cylinder();
    }
}

public class Cylinder
{
    public string GetSize()
    {
        return "2.0L";
    }
}

class Program
{
    static void Main(string[] args)
    {
      
       
        Car car2 = new Car();
        string newWay = car2.GetCylinderSize();
        Console.WriteLine($"Rozmiar cylindra (nowa metoda): {newWay}");
    }
}