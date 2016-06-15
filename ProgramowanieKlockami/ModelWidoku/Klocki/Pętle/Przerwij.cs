using System;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class Przerwij : KlocekPionowy
    {
        public override Brush Kolor => Kolory.Pętle;
        public override string Nazwa => "Przerwij";
        public override string Opis => "Przerywa wykonywanie pętli.";

        public override void Wykonaj()
        {
            KlocekPionowyZZawartością rodzic = Rodzic;

            while (rodzic != null)
            {
                rodzic.PrzerwanieWykonywania = true;

                if (Attribute.IsDefined(rodzic.GetType(), typeof(PętlaAttribute)))
                    break;

                rodzic = rodzic.Rodzic;
            }
        }
    }
}