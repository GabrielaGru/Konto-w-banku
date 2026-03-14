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

        [TestMethod]
        public void Wyplata_Debet()
        {
            KontoPlus konto = new KontoPlus("Jan Kowalski", 100, 200);

            konto.Wyplata(250);

            Assert.IsTrue(konto.Zablokowane);
        }

        [TestMethod]
        public void Wyplata_Przekracza_Limit_Debetowy()
        {
            KontoPlus konto = new KontoPlus("Jan Kowalski", 100, 200);
            Assert.Throws<InvalidOperationException>(() => konto.Wyplata(400));
        }

        [TestMethod]
        public void Wplata_Odblokowuje_Konto()
        {
            KontoPlus konto = new KontoPlus("Jan Kowalski", 100, 200);
            konto.Wyplata(250);
            konto.Wplata(200);
            Assert.IsFalse(konto.Zablokowane);
        }

        [TestMethod]
        public void Wplata_Powieksza_Bilans_KontoLimit()
        {
            KontoLimit konto = new KontoLimit("Jan Kowalski", 100, 200);
            konto.Wplata(50);
            Assert.AreEqual(350, konto.Bilans);
        }

        [TestMethod]
        public void Wyplata_W_Limit()
        {
            KontoLimit konto = new KontoLimit("Jan Kowalski", 100, 200);
            konto.Wyplata(250);
            Assert.IsTrue(konto.Zablokowane);
        }

        [TestMethod]
        public void Wyplata_Przekracza_Limit()
        {
            KontoLimit konto = new KontoLimit("Jan Kowalski", 100, 200);
            Assert.Throws<InvalidOperationException>(() => konto.Wyplata(400));
        }
    }
}
