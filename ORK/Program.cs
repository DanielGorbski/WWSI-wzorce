using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PrototypOrka
{
    public class Ork
    {
        public string Imie
        {
            get;
            set;
        }
        public int Sila
        {
            get;
            set;
        }
        public int Zdrowie
        {
            get;
            set;
        }
        public string Bron
        {
            get;
            set;
        }
        public DateTime DataUtworzenia
        {
            get;
            set;
        }

        public Ork()
        {
            Random losowanie = new Random();
            Sila = losowanie.Next(10, 201);
            Zdrowie = losowanie.Next(50, 301);
            DataUtworzenia = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Ork: {Imie}, Siła: {Sila}, Zdrowie: {Zdrowie}, Broń: {Bron}, Data: {DataUtworzenia}";
        }
    }

    class Program
    {
        static void Main()
        {

            Ork ork = new Ork
            {
                Imie = "Grom",
                Bron = "Topor"
            };

            var serializator = new Newtonsoft.Json.JsonSerializer();
            serializator.Converters.Add(new JavaScriptDateTimeConverter());
            serializator.NullValueHandling = NullValueHandling.Ignore;

            List<Ork> armiaOrkow = new List<Ork>();

            for (int i = 0; i < 10; i++)
            {
                using (StreamWriter sw = new StreamWriter(@"c:\temp\ork.txt"))
                using (Newtonsoft.Json.JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializator.Serialize(writer, ork);
                }

                using (StreamReader sr = new StreamReader(@"c:\temp\ork.txt"))
                using (Newtonsoft.Json.JsonReader reader = new JsonTextReader(sr))
                {
                    Ork klon = serializator.Deserialize<Ork>(reader);
                    klon.Imie = $"Klon Groma {i + 1}";
                    // Nowe statystyki są generowane przez konstruktor
                    armiaOrkow.Add(klon);
                }
            }

            Console.WriteLine("Oryginalny Ork:");
            Console.WriteLine(ork);
            Console.WriteLine("\nSklonowane Orki:");
            foreach (var klon in armiaOrkow)
            {
                Console.WriteLine(klon);
            }

            Console.ReadLine();
        }
    }
}