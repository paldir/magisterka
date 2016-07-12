﻿using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class UsuńElementZListy : KlocekPionowy
    {
        public override string Nazwa => "Usunięcie elementu listy";
        public override string Opis => "Usuwa z lity element o podanym indeksie.";

        public WartośćWewnętrznegoKlockaZwracającegoWartość Indeks { get; }

        public Zmienna WybranaZmienna { get; set; }

        public UsuńElementZListy()
        {
            Indeks = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(double));
            Kolor = Kolory.Listy;
        }

        public override void Wykonaj()
        {
            KlocekZwracającyWartość klocekIndeksu = Indeks[0];

            if ((WybranaZmienna != null) && (klocekIndeksu != null))
            {
                ZmiennaTypuListowego lista = WybranaZmienna.Wartość as ZmiennaTypuListowego;

                if (lista != null)
                {
                    int indeks = (int) Math.Round(klocekIndeksu.Zwróć<double>());

                    if ((indeks >= 0) && (indeks < lista.Count))
                        lista.RemoveAt(indeks);
                }
            }
        }
    }
}