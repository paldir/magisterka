using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class Napis : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override Brush Kolor => Kolory.Tekst;
        public override string Nazwa => "Napis";
        public override string Opis => "Zwraca literę, słowo lub linię tekstu.";
        public override Type ZwracanyTyp => typeof(string);

        public string Treść { get; set; }

        public Napis()
        {
            Treść = string.Empty;
        }

        protected override object ZwróćNiebezpiecznie() => Treść;
    }
}