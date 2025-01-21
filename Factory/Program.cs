using System;
using System.Collections.Generic;

public interface IWojownik
{
    string Imie
    {
        get;
    }
    void Pokaz();
}

public class Piechur : IWojownik
{
    public string Imie
    {
        get;
        private set;
    }

    public Piechur(string imie)
    {
        Imie = imie;
    }

    public void Pokaz()
    {
        Console.WriteLine($"Jestem {Imie}.");
    }
}

public class Strzelec : IWojownik
{
    public string Imie
    {
        get;
        private set;
    }

    public Strzelec(string imie)
    {
        Imie = imie;
    }

    public void Pokaz()
    {
        Console.WriteLine($"Jestem {Imie}");
    }
}

public class Konny : IWojownik
{
    public string Imie
    {
        get;
        private set;
    }

    public Konny(string imie)
    {
        Imie = imie;
    }

    public void Pokaz()
    {
        Console.WriteLine($"Jestem {Imie}");
    }
}

public class Wojownicy
{
    private Dictionary<string, Func<string, IWojownik>> fabryki;

    public Wojownicy()
    {
        fabryki = new Dictionary<string, Func<string, IWojownik>>
        {
            { "Piechur", imie => new Piechur(imie) },
            { "Strzelec", imie => new Strzelec(imie) },
            { "Konny", imie => new Konny(imie) }
        };
    }

    public IWojownik StworzWojownika(string specjalizacja, string imie)
    {
        return fabryki[specjalizacja](imie);
    }
}

public class Garnizon
{
    private Wojownicy fabryka;

    public Garnizon(Wojownicy fabryka)
    {
        this.fabryka = fabryka;
    }

    public IWojownik WyszkolWojownika(string specjalizacjaa, string imie)
    {
        return fabryka.StworzWojownika(specjalizacjaa, imie);
    }
}

public class Program
{
    public static void Main()
    {
        Wojownicy fabryka = new Wojownicy();
        Garnizon garnizon = new Garnizon(fabryka);

        List<IWojownik> wojownicy = new List<IWojownik>
        {
            garnizon.WyszkolWojownika("Piechur", "Piechur1"),
            garnizon.WyszkolWojownika("Piechur", "Piechur2"),
            garnizon.WyszkolWojownika("Piechur", "Piechur3"),
            garnizon.WyszkolWojownika("Konny", "Konny1"),
            garnizon.WyszkolWojownika("Konny", "Konny2"),
            garnizon.WyszkolWojownika("Konny", "Konny3"),
            garnizon.WyszkolWojownika("Strzelec", "Strzelec1"),
            garnizon.WyszkolWojownika("Strzelec", "Strzelec2"),
            garnizon.WyszkolWojownika("Strzelec", "Strzelec3"),
            garnizon.WyszkolWojownika("Strzelec", "Strzelec4")
        };

        foreach (var wojownik in wojownicy)
        {
            wojownik.Pokaz();
        }

        Console.ReadLine();
    }
}
