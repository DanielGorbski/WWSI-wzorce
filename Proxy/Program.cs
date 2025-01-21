using System;

public interface IStreamingService
{
    void PlayContent();
}

public class BasicSubscription : IStreamingService
{
    public void PlayContent()
    {
        Console.WriteLine("\nOdtwarzanie zawartości z pakietu podstawowego:");
        Console.WriteLine("- Filmy w jakości HD");
        Console.WriteLine("- Jeden profil użytkownika");
        Console.WriteLine("- Reklamy podczas odtwarzania");
    }
}

public class PremiumSubscription : IStreamingService
{
    public void PlayContent()
    {
        Console.WriteLine("\nOdtwarzanie zawartości z pakietu premium:");
        Console.WriteLine("- Filmy w jakości 4K HDR");
        Console.WriteLine("- Pięć profili użytkownika");
        Console.WriteLine("- Brak reklam");
        Console.WriteLine("- Dodatkowe materiały zza kulis");
    }
}

public class PremiumSubscriptionProxy : IStreamingService
{
    private readonly PremiumSubscription premiumSubscription;
    private const string VALID_PASSWORD = "premium123";

    public PremiumSubscriptionProxy()
    {
        premiumSubscription = new PremiumSubscription();
    }

    public void PlayContent()
    {
        Console.Write("\nPodaj hasło do subskrypcji premium: ");
        string enteredPassword = ReadPassword();

        if (enteredPassword == VALID_PASSWORD)
        {
            premiumSubscription.PlayContent();
        }
        else
        {
            Console.WriteLine("\nNieprawidłowe hasło! Dostęp zabroniony.");
        }
    }

    private string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Enter)
            {
                if (key.Key != ConsoleKey.Backspace)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            }
        }
        while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }
}

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Serwis Streamingowy ===");
            Console.WriteLine("1. Odtwórz zawartość z pakietu podstawowego");
            Console.WriteLine("2. Odtwórz zawartość z pakietu premium");
            Console.WriteLine("3. Wyjście");

            Console.Write("\nWybierz opcję (1-3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    IStreamingService basicSubscription = new BasicSubscription();
                    basicSubscription.PlayContent();
                    break;

                case "2":
                    IStreamingService premiumProxy = new PremiumSubscriptionProxy();
                    premiumProxy.PlayContent();
                    break;

                case "3":
                    Console.WriteLine("\nDziękujemy za korzystanie z serwisu!");
                    return;

                default:
                    Console.WriteLine("\nNieprawidłowa opcja. Spróbuj ponownie.");
                    break;
            }
        }
    }
}