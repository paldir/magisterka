using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Jeżeli : KlocekPionowyPrzyjmującyWartość
    {
        public override string Nazwa { get; } = "Jeżeli";
        public override string Opis { get; } = "Jeśli wartość jest prawdziwa, wykonuje instrukcje.";
        public override Brush KolorObramowania { get; } = Kolory.LogikaObramowanie;
        public override Brush KolorWypełnienia { get; } = Kolory.LogikaWypełnienie;
        public KlocekPionowy Zawartość { get; set; }
    }
}
