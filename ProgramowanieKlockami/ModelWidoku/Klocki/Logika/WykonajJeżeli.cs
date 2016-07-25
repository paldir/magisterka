using System.Collections.ObjectModel;
using ProgramowanieKlockami.ModelWidoku.Debugowanie;
using ProgramowanieKlockami.ModelWidoku.Klocki.Inne;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class WykonajJeżeli : KlocekPionowyZZawartościąPrzyjmującyWartość
    {
        public override string Nazwa => "Jeżeli";
        public override string Opis => "Jeśli wartość jest prawdziwa, wykonuje instrukcje.";

        public ZawartośćKlockaPionowegoZZawartością AlternatywnaZawartość { get; }

        public WykonajJeżeli() : base(typeof(bool))
        {
            AlternatywnaZawartość = new ZawartośćKlockaPionowegoZZawartością();
            Kolor = Kolory.Logika;
        }

        public override object Clone()
        {
            WykonajJeżeli kopia = (WykonajJeżeli) base.Clone();

            foreach (KlocekPionowy klocekPionowy in AlternatywnaZawartość)
                kopia.AlternatywnaZawartość.Add((KlocekPionowy) klocekPionowy.Clone());

            return kopia;
        }

        public override void Wykonaj()
        {
            object obiektWarunku = Wartość[0]?.Zwróć<object>();
            Błędy = new ObservableCollection<BłądKlocka>();
            bool wartośćWarunku;

            if (obiektWarunku is bool)
            {
                Błąd = false;
                wartośćWarunku = (bool) obiektWarunku;
            }
            else
            {
                Błąd = true;
                wartośćWarunku = false;

                Błędy.Add(new BłądKlockaUmieszczonegoWewnątrzLubPodłączonego(typeof(bool), obiektWarunku?.GetType()));
            }

            if (wartośćWarunku)
                base.Wykonaj();
            else
                foreach (KlocekPionowy klocekPionowy in AlternatywnaZawartość)
                    if (SkokPętli)
                        break;
                    else
                    {
                        if (klocekPionowy.PunktPrzerwania)
                        {
                            KlocekPionowyZZawartością klocekPionowyZZawartością = this;

                            while (!(klocekPionowyZZawartością is RozpoczęcieProgramu))
                                klocekPionowyZZawartością = klocekPionowyZZawartością.Rodzic;

                            klocekPionowyZZawartością.Debugowanie = true;
                        }

                        klocekPionowy.AktualnieWykonywany = true;

                        if (klocekPionowy.PunktPrzerwania || klocekPionowy.KrokPoKroku)
                            Semafor.Opuść();

                        klocekPionowy.Wykonaj();

                        klocekPionowy.AktualnieWykonywany = false;
                    }
        }
    }
}