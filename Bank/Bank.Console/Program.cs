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

        Console.WriteLine("\nKonwersje");

        Konto molenda = new Konto("Marek Molenda", 100);

        Console.WriteLine("Bilans na koncie podstawowym: " + molenda.Bilans);

        KontoPlus molendaPlus = molenda.NaKontoPlus(200);
        Console.WriteLine("Bilans na koncie Plus: " + molendaPlus.Bilans);

        Konto zwykle = molendaPlus.NaKonto();
        Console.WriteLine("Powrót do Konto: " + zwykle.Bilans);

        KontoLimit molendaLimit = molenda.NaKontoLimit(300);
        Console.WriteLine("Bilans na koncie Limit: " + molendaLimit.Bilans);

        Konto powrotZLimitu = molendaLimit.NaKonto();
        Console.WriteLine("Powrót do Konto: " + powrotZLimitu.Bilans);

        Console.WriteLine("\nKoniec");
    }
}