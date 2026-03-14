using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class KontoLimit
    {
        private Konto konto;
        private decimal limit;
        private bool debetUzyty = false;

        public KontoLimit(string klient, decimal bilansNaStart, decimal limit)
        {
            if (limit < 0)
            {
                throw new ArgumentException("Limit nie może być ujemny.");
            }

            konto = new Konto(klient, bilansNaStart);
            this.limit = limit;
        }

        public string Nazwa
        {
            get { return konto.Nazwa; }
        }

        public decimal Bilans
        {
            get { return konto.Bilans + limit; }

        }

        public bool Zablokowane
        {
            get { return konto.Zablokowane; }
        }

        public void ZmienLimit(decimal nowyLimit)
        {
            if (nowyLimit < 0)
            {
                throw new ArgumentException("Limit nie może być ujemny.");
            }
            limit = nowyLimit;
        }

        public void Wplata(decimal kwota)
        { 
            konto.Wplata(kwota);

            if (konto.Bilans > 0 && konto.Zablokowane)
            {
                konto.OdblokujKonto();
                debetUzyty = false;
            }
        }

        public void Wyplata(decimal kwota)
        {
            if (konto.Zablokowane)
            {
                throw new InvalidOperationException("Konto jest zablokowane.");
            }

            if (kwota <= 0)
            {
                throw new ArgumentException("Kwota wypłaty musi być większa od zera.");
            }

            decimal dostepne = konto.Bilans + limit;

            if (kwota > dostepne)
            {
                throw new InvalidOperationException("Przekroczono limit debetowy");
            }

            if (kwota <= konto.Bilans)
            {
                konto.Wyplata(kwota);
            }
            else
            {
                decimal doWyzerowania = konto.Bilans;

                if (doWyzerowania > 0)
                    konto.Wyplata(doWyzerowania);

                konto.BlokujKonto();
            }
        }
    }
}
