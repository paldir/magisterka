﻿using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Inne
{
    public class RozpoczęcieProgramu : KlocekPionowyZZawartością
    {
        public override Brush Kolor => Kolory.Funkcje;

        public override string Nazwa
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string Opis
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}