using System.Xml;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public sealed class DodajDoListy : KlocekPionowyPrzyjmującyWartość
    {
        public override string Nazwa => "Dodanie elementu do listy";
        public override string Opis => "Dodaje element na koniec listy.";

        public Zmienna WybranaZmienna { get; set; }

        public DodajDoListy() : base(typeof(object))
        {
            Kolor = Kolory.Listy;
        }

        public override object Clone()
        {
            DodajDoListy kopia = (DodajDoListy) base.Clone();
            kopia.WybranaZmienna = WybranaZmienna;

            return kopia;
        }

        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
            writer.WriteElementString("WybranaZmienna", WybranaZmienna?.Nazwa);
            writer.WriteEndElement();
        }

        public override void Wykonaj()
        {
            SprawdźPoprawnośćKlockówKonfigurujących();
            SprawdźPoprawnośćZmiennej(WybranaZmienna, typeof(ZmiennaTypuListowego));

            if (Błąd)
                return;

            ZmiennaTypuListowego lista = (ZmiennaTypuListowego) WybranaZmienna.Wartość;

            lista.Add(Wartość.Zwróć<object>(false));
        }
    }
}