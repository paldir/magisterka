using System.Collections.Generic;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Pętle
{
    public abstract class SkokWPętli : KlocekPionowy
    {
        private readonly PowódSkoku _powódSkoku;

        public override Brush Kolor => Kolory.Pętle;

        protected SkokWPętli(PowódSkoku powódSkoku)
        {
            _powódSkoku = powódSkoku;
        }

        public override void Wykonaj()
        {
            KlocekPionowyZZawartością rodzic = Rodzic;
            List<KlocekPionowyZZawartością> klockiDoPrzerwania = new List<KlocekPionowyZZawartością>();

            while (rodzic != null)
            {
                klockiDoPrzerwania.Add(rodzic);

                IPętla pętla = rodzic as IPętla;

                if (pętla != null)
                {
                    pętla.PowódSkoku = _powódSkoku;

                    break;
                }

                rodzic = rodzic.Rodzic;
            }

            if (rodzic != null)
                foreach (KlocekPionowyZZawartością klocek in klockiDoPrzerwania)
                    klocek.SkokPętli = true;
        }
    }
}