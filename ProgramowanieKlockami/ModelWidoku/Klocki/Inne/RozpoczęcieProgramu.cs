﻿using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Inne
{
    public class RozpoczęcieProgramu : KlocekPionowyPionowyZZawartością
    {
        public override string Nazwa
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string Opis
        {
            get { throw new System.NotImplementedException(); }
        }

        public override Brush Kolor => Kolory.Inne;
    }
}