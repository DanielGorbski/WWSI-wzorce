using System;
using System.Collections.Generic;

namespace Warrior
{
    public interface IWarrior
    {
        void Pokaz();
    }

    public class Strzelec : IWarrior
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
            Console.WriteLine($"Jestem Strzelec: {Imie}");
        }
    }

    public class Piechur : IWarrior
    {
        public string Imie { get; private set; }

        public Piechur(string imie)
        {
            Imie = imie;
        }

        public void Pokaz()
        {
            Console.WriteLine($"Jestem Piechur: {Imie}");
        }
    }

    public class Konny : IWarrior
    {
        public string Imie { get; private set; }

        public Konny(string imie)
        {
            Imie = imie;
        }

        public void Pokaz()
        {
            Console.WriteLine($"Jestem Konny: {Imie}");
        }
    }

    public abstract class WarriorBuilder
    {
        public abstract void ZapiszDoArmii(string imie);
        public abstract void PobierzBron();
        public abstract void Trenuj();
        public abstract IWarrior GetWarrior();
    }

    public class PiechurBuilder : WarriorBuilder
    {
        private Piechur piechur;

        public override void ZapiszDoArmii(string imie)
        {
            piechur = new Piechur(imie);
        }

        public override void PobierzBron()
        {
            Console.WriteLine("Piechur otrzymał miecz.");
        }

        public override void Trenuj()
        {
            Console.WriteLine("Piechur trenuje walczyć wręcz.");
        }

        public override IWarrior GetWarrior()
        {
            return piechur;
        }
    }

    public class StrzelecBuilder : WarriorBuilder
    {
        private Strzelec strzelec;

        public override void ZapiszDoArmii(string imie)
        {
            strzelec = new Strzelec(imie);
        }

        public override void PobierzBron()
        {
            Console.WriteLine("Strzelec otrzymał łuk.");
        }

        public override void Trenuj()
        {
            Console.WriteLine("Strzelec trenuje strzelanie z łuku.");
        }

        public override IWarrior GetWarrior()
        {
            return strzelec;
        }
    }

    public class KonnyBuilder : WarriorBuilder
    {
        private Konny konny;

        public override void ZapiszDoArmii(string imie)
        {
            konny = new Konny(imie);
        }

        public override void PobierzBron()
        {
            Console.WriteLine("Konny otrzymał lancę.");
        }

        public override void Trenuj()
        {
            Console.WriteLine("Konny trenuje jazdę konną.");
        }

        public override IWarrior GetWarrior()
        {
            return konny;
        }
    }

    public class Garnizon
    {
        public void SzkolWojownika(WarriorBuilder builder, string imie)
        {
            builder.ZapiszDoArmii(imie);
            builder.PobierzBron();
            builder.Trenuj();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Garnizon garnizon = new Garnizon();

            List<IWarrior> wojownicy = new List<IWarrior>();

            PiechurBuilder piechurBuilder = new PiechurBuilder();
            garnizon.SzkolWojownika(piechurBuilder, "Piechur 1");
            wojownicy.Add(piechurBuilder.GetWarrior());
            garnizon.SzkolWojownika(piechurBuilder, "Piechur 2");
            wojownicy.Add(piechurBuilder.GetWarrior());

            KonnyBuilder konnyBuilder = new KonnyBuilder();
            garnizon.SzkolWojownika(konnyBuilder, "Konny 1");
            wojownicy.Add(konnyBuilder.GetWarrior());
            garnizon.SzkolWojownika(konnyBuilder, "Konny 2");
            wojownicy.Add(konnyBuilder.GetWarrior());

            StrzelecBuilder strzelecBuilder = new StrzelecBuilder();
            garnizon.SzkolWojownika(strzelecBuilder, "Strzelec 1");
            wojownicy.Add(strzelecBuilder.GetWarrior());
            garnizon.SzkolWojownika(strzelecBuilder, "Strzelec 2");
            wojownicy.Add(strzelecBuilder.GetWarrior());

            foreach (var wojownik in wojownicy)
            {
                wojownik.Pokaz();
            }
            Console.ReadLine();
        }
    }
}