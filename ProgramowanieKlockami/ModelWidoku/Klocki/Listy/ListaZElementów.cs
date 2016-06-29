using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.Matematyka;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class ListaZElementów : KlocekZwracającyWartość
    {
        private uint _liczbaElementów;

        protected override WartośćKlockaPrzyjmującegoWartość[] KlockiKonfigurujące => new WartośćKlockaPrzyjmującegoWartość[0];

        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Inicjalizacja listy";
        public override string Opis => "Tworzy listę złożoną z dowolnej liczby elementów.";
        public override Type ZwracanyTyp => typeof(List<object>);

        public ObservableCollection<WartośćKlockaPrzyjmującegoWartość> Elementy { get; }

        public uint LiczbaElementów
        {
            get { return _liczbaElementów; }

            set
            {
                _liczbaElementów = value;
                int aktualnaLiczbaElementów = Elementy.Count;

                if (aktualnaLiczbaElementów < LiczbaElementów)
                    for (int i = aktualnaLiczbaElementów; i < LiczbaElementów; i++)
                    {
                        WartośćKlockaPrzyjmującegoWartość wartośćKlockaPrzyjmującegoWartość = new WartośćKlockaPrzyjmującegoWartość(typeof(object));

                        Elementy.Add(wartośćKlockaPrzyjmującegoWartość);
                    }
                else
                    for (int i = aktualnaLiczbaElementów - 1; i >= LiczbaElementów; i--)
                        Elementy.RemoveAt(i);
            }
        }

        public ListaZElementów()
        {
            Elementy = new ObservableCollection<WartośćKlockaPrzyjmującegoWartość>();
        }

        protected override object ZwróćNiebezpiecznie()
        {
            List<object> lista = new List<object>();

            foreach (WartośćKlockaPrzyjmującegoWartość wartośćKlockaPrzyjmującegoWartość in Elementy)
            {
                KlocekZwracającyWartość klocekZwracającyWartość = wartośćKlockaPrzyjmującegoWartość[0];

                if (klocekZwracającyWartość != null)
                    lista.Add(klocekZwracającyWartość.Zwróć<object>());
            }

            return lista;
        }
    }
}