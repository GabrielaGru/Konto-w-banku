using System;
using Bank;

class   Program
{
    static void Main()
    {
        Console.WriteLine("Konto Podstawowe");

        Konto konto = new Konto("Jan Kowalski", 500);

        konto.Wplata(200);
        Console.WriteLine("Bilans po wpłacie: " + konto.Bilans);

        konto.Wyplata(100);
        Console.WriteLine("Bilans po wypłacie: " + konto.Bilans);

        Console.WriteLine("\nKonto Plus");

        KontoPlus kontoPlus = new KontoPlus("Anna Nowak", 300, 200);

        Console.WriteLine("Bilans początkowy: " + kontoPlus.Bilans);

        kontoPlus.Wyplata(450);
        Console.WriteLine("Bilans po wypłacie: " + kontoPlus.Bilans);
        Console.WriteLine("Czy konto jest zablokowane: " + kontoPlus.Zablokowane);

        kontoPlus.Wplata(200);
        Console.WriteLine("Bilans po wpłacie: " + kontoPlus.Bilans);
        Console.WriteLine("Czy konto jest zablokowane: " + kontoPlus.Zablokowane);

        Console.WriteLine("\nKonto Limit");

        KontoLimit kontoLimit = new KontoLimit("Piotr Wiśniewski", 400, 300);

        Console.WriteLine("Bilans początkowy: " + kontoLimit.Bilans);

        kontoLimit.Wyplata(600);
        Console.WriteLine("Bilans po wypłacie: " + kontoLimit.Bilans);
        Console.WriteLine("Czy konto jest zablokowane: " + kontoLimit.Zablokowane);

        kontoLimit.Wplata(300);
        Console.WriteLine("Bilans po wpłacie: " + kontoLimit.Bilans);
        Console.WriteLine("Czy konto jest zablokowane: " + kontoLimit.Zablokowane);

        Console.WriteLine("\nKoniec");
    }
}