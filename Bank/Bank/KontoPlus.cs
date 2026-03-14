using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class KontoPlus : Konto
    {
        private decimal limitDebetowy;

        public KontoPlus(string klient, decimal bilansNaStart, decimal limitDebetowy) : base(klient, bilansNaStart)
        {
            if (limitDebetowy < 0)
            {
                throw new ArgumentException("Limit debetowy nie może być ujemny");
            }
            this.limitDebetowy = limitDebetowy;
        }

        public decimal LimitDebetowy
        {
            get { return limitDebetowy; }
        }

        public void ZmienLimitDebetowy(decimal nowyLimit)
        {
            if (nowyLimit < 0)
            {
                throw new ArgumentException("Limit nie może być ujemny.");
            }
            limitDebetowy = nowyLimit;
        }

        public override decimal Bilans
        { 
            get { return base.Bilans + limitDebetowy; }
        }

        public override void Wyplata(decimal kwota)
        {
            if (Zablokowane)
            {
                throw new InvalidOperationException("Konto jest zablokowane.");
            }
            decimal dostepne = base.Bilans + limitDebetowy;

            if(kwota>dostepne)
            {
                throw new InvalidOperationException("Niewystarczające środki na koncie.");
            }
            bilans-= kwota;

            if (bilans < 0)
            { 
                BlokujKonto();
            }
        }

        public override void Wplata(decimal kwota)
        {
            if (kwota <= 0)
                throw new ArgumentException("Kwota musi być większa od zera");

            bilans += kwota;

            if (bilans > 0 && Zablokowane)
                OdblokujKonto();
        }
    }
}
