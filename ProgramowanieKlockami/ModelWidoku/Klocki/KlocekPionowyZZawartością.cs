﻿using System.Linq;
using System.Xml;
using ProgramowanieKlockami.ModelWidoku.Klocki.Inne;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyZZawartością : KlocekPionowy
    {
        private bool _rozwinięty;

        public ZawartośćKlockaPionowegoZZawartością Zawartość { get; }

        public bool SkokPętli { get; set; }

        public bool Rozwinięty
        {
            get { return _rozwinięty; }

            set
            {
                _rozwinięty = value;

                OnPropertyChanged();
            }
        }

        protected KlocekPionowyZZawartością()
        {
            Zawartość = new ZawartośćKlockaPionowegoZZawartością {KlocekPionowyZZawartością = this};
            Rozwinięty = true;
        }

        public override object Clone()
        {
            KlocekPionowyZZawartością kopia = (KlocekPionowyZZawartością) base.Clone();

            foreach (KlocekPionowy klocekPionowy in Zawartość)
                kopia.Zawartość.Add((KlocekPionowy) klocekPionowy.Clone());

            return kopia;
        }

        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
            writer.WriteStartElement("Zawartość");

            foreach (KlocekPionowy klocekPionowy in Zawartość)
                klocekPionowy.WriteXml(writer);

            writer.WriteEndElement();
        }

        public override void Wykonaj()
        {
            foreach (KlocekPionowy klocekPionowy in Zawartość)
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

        public static void ZresetujRekurencyjnieFlagęSkokuWPętli(KlocekPionowyZZawartością klocekPionowyZZawartością)
        {
            klocekPionowyZZawartością.SkokPętli = false;

            foreach (KlocekPionowyZZawartością klocek in klocekPionowyZZawartością.Zawartość.Where(k => k is KlocekPionowyZZawartością).Cast<KlocekPionowyZZawartością>())
                ZresetujRekurencyjnieFlagęSkokuWPętli(klocek);
        }
    }
}