using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Bank
{
    public class KontoLimit
    {
        private Konto konto;
        private decimal limit;
        private decimal debet = 0;
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
            get { return konto.Bilans - debet + limit; }

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
            if (kwota <= 0)
                throw new ArgumentException("Kwota musi być większa od zera");

            if (debet > 0)
            {
                if (kwota >= debet)
                {
                    kwota -= debet;
                    debet = 0;

                    if (konto.Zablokowane)
                        konto.OdblokujKonto();
                }
                else
                {
                    debet -= kwota;
                    return;
                }
            }

            if (kwota > 0)
                konto.Wplata(kwota);
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
                decimal brakujace = kwota - konto.Bilans;

                if (konto.Bilans > 0)
                    konto.Wyplata(konto.Bilans);

                debet = brakujace;
                konto.BlokujKonto();
            }
        }
        
        //krok 5
        public Konto NaKonto()
        {
            return new Konto(this.Nazwa, konto.Bilans - debet);
        }
    }
}
