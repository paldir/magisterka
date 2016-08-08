using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class LiteraTekstu : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Tekst, Indeks};

        public override string Nazwa => "Litera tekstu";
        public override string Opis => "Zwraca literę z podanej pozycji.";
        public override Type ZwracanyTyp => typeof(object);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Indeks { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Tekst { get; }

        public LiteraTekstu()
        {
            Indeks = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Kolor = Kolory.Tekst;
            Tekst = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(object));
        }

        protected override object ZwróćNiebezpiecznie(bool sprawdzanieBłędów)
        {
            int indeks = (int) Math.Round(Indeks.Zwróć<double>(sprawdzanieBłędów));
            string tekst = Tekst.Zwróć<object>(sprawdzanieBłędów).ToString();
            int długośćTekstu = tekst.Length;

            if (indeks < 0)
                indeks = 0;

            if (indeks >= długośćTekstu)
                indeks = długośćTekstu - 1;

            return długośćTekstu > 0 ? tekst[indeks].ToString() : string.Empty;
        }

        public override object Clone()
        {
            LiteraTekstu kopia = (LiteraTekstu) base.Clone();
            kopia.Indeks[0] = (KlocekZwracającyWartość) Indeks[0]?.Clone();
            kopia.Tekst[0] = (KlocekZwracającyWartość) Tekst[0]?.Clone();

            return kopia;
        }
    }
}