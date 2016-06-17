﻿using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka.FunkcjeMatematyczne
{
    public class WartośćBezwzględna : IOpcjaZwracającaWartośćNaPodstawieParametru<double, double>
    {
        public string ReprezentacjaTekstowa => "Wartość bezwzględna z";

        public double Zwróć(double x) => Math.Abs(x);
    }
}