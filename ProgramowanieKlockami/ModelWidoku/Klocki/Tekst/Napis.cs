using System;
using System.Xml;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst
{
    public sealed class Napis : KlocekZwracającyWartość
    {
        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override string Nazwa => "Napis";
        public override string Opis => "Zwraca literę, słowo lub linię tekstu.";
        public override Type ZwracanyTyp => typeof(string);

        public string Treść { get; set; }

        public Napis()
        {
            Kolor = Kolory.Tekst;
            Treść = string.Empty;
        }

        protected override object ZwróćNiebezpiecznie(bool sprawdzanieBłędów) => Treść;

        public override object Clone()
        {
            Napis kopia = (Napis) base.Clone();
            kopia.Treść = (string) Treść.Clone();

            return kopia;
        }

        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
            writer.WriteElementString("Treść", Treść);
            writer.WriteEndElement();
        }
    }
}