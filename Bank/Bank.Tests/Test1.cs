namespace Bank.Tests
{
    [TestClass]
    public class KontoTests
    {
        [TestMethod]
        public void Wplata_Powieksza_Bilans()
        {
            Konto konto = new Konto("Jan Kowalski", 100);

            konto.Wplata(50);

            Assert.AreEqual(150, konto.Bilans);
        }

        [TestMethod]
        public void Wyplata_Pomniejsza_Bilans()
        {
            Konto konto = new Konto("Jan Kowalski", 200);
            konto.Wyplata(50);
            Assert.AreEqual(150, konto.Bilans);
        }

        [TestMethod]
        public void Wyplata_Brak_Srodkow()
        { 
            Konto konto = new Konto("Jan Kowalski", 100);
            Assert.Throws<InvalidOperationException>(() => konto.Wyplata(200));
        }

        [TestMethod]
        public void Wplata_Konto_Zablokowane()
        {
            Konto konto = new Konto("Jan Kowalski", 100);
            konto.BlokujKonto();
            Assert.Throws<InvalidOperationException>(() => konto.Wplata(50));
        }

        [TestMethod]
        public void Wyplata_Konto_Zablokowane()
        {
            Konto konto = new Konto("Jan Kowalski", 100);
            konto.BlokujKonto();
            Assert.Throws<InvalidOperationException>(() => konto.Wyplata(50));
        }
    }
}
