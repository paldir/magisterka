using System;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.Listy.ModyfikacjaElementuListy;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class ModyfikujElementListy : KlocekPionowy
    {
        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Modyfikacja elementu listy";
        public override string Opis => "Ustawia element listy albo wstawia go w określone miejsce.";

        public WartośćWewnętrznegoKlockaZwracającegoWartość Indeks { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Wartość { get; }

        public Zmienna WybranaZmienna { get; set; }
        public ITypUstawieniaElementuListy WybranyTypModyfikacjiListy { get; set; }

        public ModyfikujElementListy()
        {
            Indeks = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Wartość = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(object));
        }

        public override object Clone()
        {
            ModyfikujElementListy kopia = (ModyfikujElementListy) base.Clone();
            kopia.WybranyTypModyfikacjiListy = WybranyTypModyfikacjiListy;

            return kopia;
        }

        public override void Wykonaj()
        {
            if (WybranaZmienna != null)
            {
                ZmiennaTypuListowego lista = WybranaZmienna.Wartość as ZmiennaTypuListowego;
                KlocekZwracającyWartość klocekIndeksu = Indeks[0];
                KlocekZwracającyWartość klocekWartości = Wartość[0];

                if ((lista != null) && (klocekIndeksu != null) && (klocekWartości != null))
                {
                    int indeks = (int) Math.Round(klocekIndeksu.Zwróć<double>());
                    object wartość = klocekWartości.Zwróć<object>();

                    WybranyTypModyfikacjiListy.ModyfikujListę(lista, indeks, wartość);
                }
            }
        }
    }
}