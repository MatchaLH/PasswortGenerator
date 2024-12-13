using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Zufallspasswort-Generator!");

        Console.Write("Gib die gewünschte Passwortlänge ein: ");
        int Länge;
        while (!int.TryParse(Console.ReadLine(), out Länge) || Länge <= 0)
        {
            Console.Write("Ungültige Eingabe, gib eine andere Zahl ein");
        }

        Console.WriteLine("Welche Zeichen sollen enthalten sein?");
        Console.Write("Grossbuchstaben (A-Z)? (j/n)      :");
        bool gross = Console.ReadLine().ToLower() == "j";

        Console.Write("Kleinbuchstaben (a-z)? (j/n)      :");
        bool klein = Console.ReadLine().ToLower() == "j";

        Console.Write("Zahlen (0-9)? (j/n)               :");
        bool nummer = Console.ReadLine().ToLower() == "j";

        Console.Write("Sonderzeichen (!@#$%^&*...)? (j/n):");
        bool zeichen = Console.ReadLine().ToLower() == "j";

        string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string lowerChars = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "0123456789";
        string specialChars = "!@#$%^&*()-_=+[]{}|;:',.<>?/";

        StringBuilder charPool = new StringBuilder();
        if (gross) charPool.Append(upperChars);
        if (klein) charPool.Append(lowerChars);
        if (nummer) charPool.Append(numbers);
        if (zeichen) charPool.Append(specialChars);

        if (charPool.Length == 0)
        {
            Console.WriteLine("Du musst mindestens eine Zeichenart auswählen!");
            return;
        }

        Random random = new Random();
        StringBuilder passwort = new StringBuilder();

        for (int i = 0; i < Länge; i++)
        {
            int zufall = random.Next(charPool.Length);
            passwort.Append(charPool[zufall]);
        }

        Console.WriteLine($"\nDein generiertes Passwort ist: {passwort}");
    }
}
