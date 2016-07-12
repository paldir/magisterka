using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.KlockiZwracająceWartośćNaPodstawieWyboruOpcji;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika
{
    public class Porównanie : KlocekZwracającyWartośćNaPodstawieOpcjiIDwóchParametrów<bool, IComparable, IComparable>
    {
        public override string Nazwa => "Porównanie";
        public override string Opis => "Zwraca prawdę, jeśli oba wejścia są takie same.";

        public Porównanie()
        {
            Kolor = Kolory.Logika;
        }
    }
}