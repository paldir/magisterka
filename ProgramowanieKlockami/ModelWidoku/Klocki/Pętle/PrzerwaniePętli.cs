using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public class PrzerwaniePętli : KlocekPionowy
    {
        public override Brush Kolor => Kolory.Pętle;
        public override string Nazwa => "Przerwanie pętli";
        public override string Opis => "Przerywa wykonywanie pętli.";

        public override void Wykonaj()
        {
            KlocekPionowyZZawartością rodzic = Rodzic;
            List<KlocekPionowyZZawartością> klockiDoPrzerwania = new List<KlocekPionowyZZawartością>();

            while (rodzic != null)
            {
                klockiDoPrzerwania.Add(rodzic);

                if (Attribute.IsDefined(rodzic.GetType(), typeof(PętlaAttribute)))
                    break;

                rodzic = rodzic.Rodzic;
            }

            if (rodzic != null)
                foreach (KlocekPionowyZZawartością klocek in klockiDoPrzerwania)
                    klocek.PrzerwanieWykonywania = true;
        }
    }
}