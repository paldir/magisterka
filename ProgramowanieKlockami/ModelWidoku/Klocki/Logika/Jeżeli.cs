using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Jeżeli : KlocekPionowyPrzyjmującyWartość
    {
        public override string Nazwa { get; } = "Jeżeli";
        public override string Opis { get; } = "Jeśli wartość jest prawdziwa, wykonuje instrukcje.";
        public override Brush Kolor => Kolory.Logika;
        public KlocekPionowy Zawartość { get; set; }
    }
}
