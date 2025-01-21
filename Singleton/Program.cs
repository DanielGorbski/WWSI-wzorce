using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonVault
{

    public class Vault
    {

        private string key;

        private static Vault _instance = null;
        private Vault()
        {

        }
        public static Vault GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Vault();
                    }
                }
            }
            return _instance;
        }
    }
    static byte[] GeneratePseudoRandomKey(int size)
    {
        byte[] key = new byte[size];
        Random random = new Random();
        random.NextBytes(key);
        return key;
    }
    class Program
    {
        static void Main(string[] args)
        {

            int keySize = 4;

            // Generowanie klucza
            byte[] key = GeneratePseudoRandomKey(keySize);


            Vault vault1 = Vault.GetInstance();

            // Próba pobrania klucza
            Console.WriteLine("Próba pobrania klucza z vault1: " + vault1(key));

            // Druga próba pobrania klucza (powinna zwrócić komunikat, że klucz został już użyty)
            Console.WriteLine("Próba ponownego pobrania klucza z vault1: " + vault1(key));

            // Próba pobrania klucza z innej referencji (ale to nadal ta sama instancja Singleton)
            Vault vault2 = Vault.GetInstance();
            Console.WriteLine("Próba pobrania klucza z vault2: " + vault2(key));

            Console.ReadLine();
        }
    }
}