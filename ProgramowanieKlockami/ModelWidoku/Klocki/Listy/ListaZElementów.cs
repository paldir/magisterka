using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class ListaZElementów : KlocekZwracającyWartość
    {
        private uint _liczbaElementów;

        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Inicjalizacja listy";
        public override string Opis => "Tworzy listę złożoną z dowolnej liczby elementów.";
        public override Type ZwracanyTyp => typeof(ZmiennaTypuListowego);

        public ObservableCollection<WartośćWewnętrznegoKlockaZwracającegoWartość> Elementy { get; }

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
                        WartośćWewnętrznegoKlockaZwracającegoWartość wartośćKlockaPrzyjmującegoWartość = new WartośćWewnętrznegoKlockaZwracającegoWartość(typeof(object));

                        Elementy.Add(wartośćKlockaPrzyjmującegoWartość);
                    }
                else
                    for (int i = aktualnaLiczbaElementów - 1; i >= LiczbaElementów; i--)
                        Elementy.RemoveAt(i);
            }
        }

        public ListaZElementów()
        {
            Elementy = new ObservableCollection<WartośćWewnętrznegoKlockaZwracającegoWartość>();
        }

        protected override object ZwróćNiebezpiecznie()
        {
            ZmiennaTypuListowego lista = new ZmiennaTypuListowego();

            foreach (WartośćWewnętrznegoKlockaZwracającegoWartość wartośćKlockaPrzyjmującegoWartość in Elementy)
            {
                KlocekZwracającyWartość klocekZwracającyWartość = wartośćKlockaPrzyjmującegoWartość[0];

                if (klocekZwracającyWartość != null)
                    lista.Add(klocekZwracającyWartość.Zwróć<object>());
            }

            return lista;
        }
    }
}