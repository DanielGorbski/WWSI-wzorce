using System;

public class Car
{
    public Engine GetEngine()
    {
        return new Engine();
    }

    public string GetCylinderSize()
    {
        Engine engine = GetEngine();
        Cylinder cylinder = engine.GetCylinder();
        return cylinder.GetSize();
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

public class Program
{
    public static void Main(string[] args)
    {
        Car car = new Car();
        string cylinderSize = car.GetCylinderSize();

        Console.WriteLine($"Cylinder Size: {cylinderSize}");
    }
}