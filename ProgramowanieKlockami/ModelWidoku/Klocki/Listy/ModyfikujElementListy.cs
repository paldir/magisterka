using System;
using System.Xml;
using ProgramowanieKlockami.ModelWidoku.Klocki.Listy.ModyfikacjaElementuListy;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class ModyfikujElementListy : KlocekPionowy
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new[] {Indeks, Wartość};

        public override string Nazwa => "Modyfikacja elementu listy";
        public override string Opis => "Ustawia element listy albo wstawia go w określone miejsce.";

        public WartośćWewnętrznegoKlockaZwracającegoWartość Indeks { get; }
        public WartośćWewnętrznegoKlockaZwracającegoWartość Wartość { get; }

        public Zmienna WybranaZmienna { get; set; }
        public ITypUstawieniaElementuListy WybranyTypModyfikacjiListy { get; set; }

        public ModyfikujElementListy()
        {
            Indeks = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Kolor = Kolory.Listy;
            Wartość = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(object));
        }

        public override object Clone()
        {
            ModyfikujElementListy kopia = (ModyfikujElementListy) base.Clone();
            kopia.Indeks[0] = (KlocekZwracającyWartość) Indeks[0]?.Clone();
            kopia.Wartość[0] = (KlocekZwracającyWartość) Wartość[0]?.Clone();
            kopia.WybranaZmienna = WybranaZmienna;
            kopia.WybranyTypModyfikacjiListy = WybranyTypModyfikacjiListy;

            return kopia;
        }

        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);

        }

        public override void Wykonaj()
        {
            SprawdźPoprawnośćKlockówKonfigurujących();
            SprawdźPoprawnośćZmiennej(WybranaZmienna, typeof(ZmiennaTypuListowego));

            if (Błąd)
                return;

            ZmiennaTypuListowego lista = (ZmiennaTypuListowego) WybranaZmienna.Wartość;
            int indeks = (int) Math.Round(Indeks.Zwróć<double>(false));
            object wartość = Wartość.Zwróć<object>(false);

            WybranyTypModyfikacjiListy.ModyfikujListę(lista, indeks, wartość);
        }
    }
}