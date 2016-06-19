﻿using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.SposobyZaokrąglania
{
    public class Zaokrąglanie : IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>
    {
        public string ReprezentacjaTekstowa => "Zaokrąglij";

        public double Zwróć(double x) => Math.Round(x);
    }
}