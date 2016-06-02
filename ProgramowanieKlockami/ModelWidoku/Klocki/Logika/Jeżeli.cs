using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Jeżeli : KlocekPionowyZZawartościąPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Logika;
        public override string Nazwa => "Jeżeli";
        public override string Opis => "Jeśli wartość jest prawdziwa, wykonuje instrukcje.";

        public override void Wykonaj()
        {
            object wartośćWarunku = Wartość[0]?.Zwróć();

            if (wartośćWarunku is bool && (bool) wartośćWarunku)
                base.Wykonaj();
        }
    }
}