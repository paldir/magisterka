using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Jeżeli : KlocekPionowyZZawartościąPrzyjmującyWartość
    {
        public override string Nazwa => "Jeżeli";
        public override string Opis => "Jeśli wartość jest prawdziwa, wykonuje instrukcje.";
        public override Brush Kolor => Kolory.Logika;
    }
}