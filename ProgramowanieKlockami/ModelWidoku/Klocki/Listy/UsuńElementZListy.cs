using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class UsuńElementZListy : KlocekPionowy
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Indeks};

        public override string Nazwa => "Usunięcie elementu listy";
        public override string Opis => "Usuwa z lity element o podanym indeksie.";

        public WartośćWewnętrznegoKlockaZwracającegoWartość Indeks { get; }

        public Zmienna WybranaZmienna { get; set; }

        public UsuńElementZListy()
        {
            Indeks = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Kolor = Kolory.Listy;
        }

        public override object Clone()
        {
            UsuńElementZListy kopia = (UsuńElementZListy) base.Clone();
            kopia.Indeks[0] = (KlocekZwracającyWartość) Indeks[0]?.Clone();
            kopia.WybranaZmienna = WybranaZmienna;

            return kopia;
        }

        public override void Wykonaj()
        {
            KlocekZwracającyWartość klocekIndeksu = Indeks[0];

            if ((WybranaZmienna != null) && (klocekIndeksu != null))
            {
                ZmiennaTypuListowego lista = WybranaZmienna.Wartość as ZmiennaTypuListowego;

                if (lista != null)
                {
                    int indeks = (int) Math.Round(klocekIndeksu.Zwróć<double>());

                    if ((indeks >= 0) && (indeks < lista.Count))
                        lista.RemoveAt(indeks);
                }
            }
        }
    }
}