﻿namespace ProgramowanieKlockami.ModelWidoku.Tekst
{
    public class Napis : KlocekZwracającyWartość
    {
        public override string Nazwa
        {
            get { return "Napis"; }
        }

        public override string Opis
        {
            get { return "Zwraca literę, słowo lub linię tekstu."; }
        }
    }
}