using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w Gilded Rose!");

            IList<Przedmiot> przedmioty = new List<Przedmiot>
            {
                new Przedmiot { Nazwa = "Aged Brie", SprzedajPrzed = 10, Jakosc = 20 },
                new Przedmiot { Nazwa = "Sulfuras, Hand of Ragnaros", SprzedajPrzed = 0, Jakosc = 80 },
                new Przedmiot { Nazwa = "Backstage passes to a TAFKAL80ETC concert", SprzedajPrzed = 15, Jakosc = 20 },
                new Przedmiot { Nazwa = "Zwykły Przedmiot", SprzedajPrzed = 5, Jakosc = 7 }
            };

            var aplikacja = new GildedRose(przedmioty);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Dzień {i + 1}");
                aplikacja.AktualizujJakosc();
                foreach (var przedmiot in przedmioty)
                {
                    Console.WriteLine(przedmiot);
                }
                Console.WriteLine();
            }
        }
    }

    public class GildedRose
    {
        private IList<Przedmiot> Przedmioty;

        public GildedRose(IList<Przedmiot> przedmioty)
        {
            Przedmioty = przedmioty;
        }

        public void AktualizujJakosc()
        {
            foreach (var przedmiot in Przedmioty)
            {
                if (przedmiot.Nazwa == "Sulfuras, Hand of Ragnaros")
                    continue;

                if (przedmiot.Nazwa == "Aged Brie")
                {
                    przedmiot.Jakosc = Math.Min(50, przedmiot.Jakosc + 1);
                }
                else if (przedmiot.Nazwa.StartsWith("Backstage passes"))
                {
                    if (przedmiot.SprzedajPrzed > 10)
                        przedmiot.Jakosc += 1;
                    else if (przedmiot.SprzedajPrzed > 5)
                        przedmiot.Jakosc += 2;
                    else if (przedmiot.SprzedajPrzed > 0)
                        przedmiot.Jakosc += 3;
                    else
                        przedmiot.Jakosc = 0;
                }
                else
                {
                    przedmiot.Jakosc = Math.Max(0, przedmiot.Jakosc - 1);
                }

                przedmiot.SprzedajPrzed--;
            }
        }
    }

    public class Przedmiot
    {
        public string Nazwa { get; set; }
        public int SprzedajPrzed { get; set; }
        public int Jakosc { get; set; }

        public override string ToString()
        {
            return $"{Nazwa}, Sprzedaj przed: {SprzedajPrzed}, Jakość: {Jakosc}";
        }
    }
}
