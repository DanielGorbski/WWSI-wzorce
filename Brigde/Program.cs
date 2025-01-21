using System;
using System.Collections.Generic;

namespace SklepDekoratory
{
    public interface IDekorator
    {
        void Wykonaj();
    }
    public class WyslijSMS : IDekorator
    {
        public void Wykonaj()
        {
            Console.WriteLine("Powiadomienie SMS: Płatność została dokonana.");
        }
    }

    public class DodajPunktyLojalnosciowe : IDekorator
    {
        public void Wykonaj()
        {
            Console.WriteLine("Dodano punkty lojalnościowe.");
        }
    }

    public class PrzekierujNaStroneGlowna : IDekorator
    {
        public void Wykonaj()
        {
            Console.WriteLine("Przekierowanie na stronę główną sklepu.");
        }
    }

    public class Produkt
    {
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }

        public Produkt(string nazwa, decimal cena)
        {
            Nazwa = nazwa;
            Cena = cena;
        }
    }

    public class Koszyk
    {
        private readonly List<Produkt> produkty = new List<Produkt>();

        public void DodajProdukt(Produkt produkt)
        {
            produkty.Add(produkt);
            Console.WriteLine($"Dodano produkt: {produkt.Nazwa}, cena: {produkt.Cena:C}");
        }

        public void WyswietlZawartosc()
        {
            Console.WriteLine("Zawartość koszyka:");
            foreach (var produkt in produkty)
            {
                Console.WriteLine($"- {produkt.Nazwa}, cena: {produkt.Cena:C}");
            }
            Console.WriteLine($"Łączna kwota: {ObliczLacznaCene():C}");
        }

        public decimal ObliczLacznaCene()
        {
            decimal suma = 0;
            foreach (var produkt in produkty)
            {
                suma += produkt.Cena;
            }
            return suma;
        }

        public void WyczyscKoszyk()
        {
            produkty.Clear();
            Console.WriteLine("Koszyk został opróżniony.");
        }
    }

    // Klasa sklepu
    public class Sklep
    {
        private readonly Koszyk koszyk = new Koszyk();
        private readonly List<IDekorator> dekoratory = new List<IDekorator>();

        public void DodajDekorator(IDekorator dekorator)
        {
            dekoratory.Add(dekorator);
        }

        public void DodajDoKoszyka(Produkt produkt)
        {
            koszyk.DodajProdukt(produkt);
        }

        public void ZatwierdzZakupy()
        {
            Console.WriteLine("Zakupy zatwierdzone.");
            koszyk.WyswietlZawartosc();
            WybierzMetodePlatnosci();
        }

        private void WybierzMetodePlatnosci()
        {
            Console.WriteLine("Wybierz metodę płatności:");
            Console.WriteLine("1. Gotówka");
            Console.WriteLine("2. PayPal");
            Console.WriteLine("3. Karta");

            int wybor = int.Parse(Console.ReadLine());

            switch (wybor)
            {
                case 1:
                    ZaplacGotowka();
                    break;
                case 2:
                    ZaplacPayPal();
                    break;
                case 3:
                    ZaplacKarta();
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    break;
            }
        }

        private void ZaplacGotowka()
        {
            Console.WriteLine("Płatność gotówką została przetworzona.");
        }

        private void ZaplacPayPal()
        {
            Console.WriteLine("Płatność przez PayPal została przetworzona.");
        }

        private void ZaplacKarta()
        {
            Console.WriteLine("Płatność kartą została przetworzona.");
            foreach (var dekorator in dekoratory)
            {
                dekorator.Wykonaj();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Sklep sklep = new Sklep();

            // Dodanie dekoratorów
            sklep.DodajDekorator(new WyslijSMS());
            sklep.DodajDekorator(new DodajPunktyLojalnosciowe());
            sklep.DodajDekorator(new PrzekierujNaStroneGlowna());

            while (true)
            {
                Console.WriteLine("1. Dodaj produkt do koszyka");
                Console.WriteLine("2. Pokaż zawartość koszyka");
                Console.WriteLine("3. Zatwierdź zakupy i zapłać");
                Console.WriteLine("4. Wyjdź");

                int wybor = int.Parse(Console.ReadLine());

                switch (wybor)
                {
                    case 1:
                        Console.WriteLine("Podaj nazwę produktu:");
                        string nazwa = Console.ReadLine();
                        Console.WriteLine("Podaj cenę produktu:");
                        decimal cena = decimal.Parse(Console.ReadLine());
                        sklep.DodajDoKoszyka(new Produkt(nazwa, cena));
                        break;
                    case 2:
                        sklep.DodajDoKoszyka(new Produkt("Koszyk", 0));
                        break;
                    case 3:
                        sklep.ZatwierdzZakupy();
                        return;
                    case 4:
                        Console.WriteLine("Dziękujemy za wizytę!");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór.");
                        break;
                }
            }
        }
    }
}
