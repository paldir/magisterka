using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public class Podciąg : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Tekst, Indeks1, Indeks2};

        public override string Nazwa => "Podciąg";
        public override string Opis => "Zwraca określony fragment tekstu.";
        public override Type ZwracanyTyp => typeof(object);

        public WartośćWewnętrznegoKlockaZwracającegoWartość Indeks1 { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Indeks2 { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Tekst { get; }

        public Podciąg()
        {
            Indeks1 = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Indeks2 = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Kolor = Kolory.Tekst;
            Tekst = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(object));
        }

        protected override object ZwróćNiebezpiecznie(bool sprawdzanieBłędów)
        {
            string tekst = Tekst.Zwróć<object>().ToString();
            int indeks1 = (int) Math.Round(Indeks1.Zwróć<double>());
            int indeks2 = (int) Math.Round(Indeks2.Zwróć<double>());
            int długośćTekstu = tekst.Length;

            if (indeks1 > indeks2)
            {
                int tmp = indeks1;
                indeks1 = indeks2;
                indeks2 = tmp;
            }

            if (indeks1 < 0)
                indeks1 = 0;

            if (indeks2 >= długośćTekstu)
                indeks2 = długośćTekstu - 1;

            return tekst.Substring(indeks1, indeks2 - indeks1 + 1);
        }

        public override object Clone()
        {
            Podciąg kopia = (Podciąg) base.Clone();
            kopia.Indeks1[0] = (KlocekZwracającyWartość) Indeks1[0]?.Clone();
            kopia.Indeks2[0] = (KlocekZwracającyWartość) Indeks2[0]?.Clone();
            kopia.Tekst[0] = (KlocekZwracającyWartość) Tekst[0]?.Clone();

            return kopia;
        }
    }
}