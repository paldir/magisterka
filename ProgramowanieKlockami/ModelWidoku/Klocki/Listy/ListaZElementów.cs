using System;
using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class ListaZElementów : KlocekZwracającyWartość
    {
        private uint _liczbaElementów;

        protected override WartośćWewnętrznegoKlockaZwracającegoWartość[] KlockiKonfigurujące => new WartośćWewnętrznegoKlockaZwracającegoWartość[0];

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
            Kolor = Kolory.Listy;
        }

        protected override object ZwróćNiebezpiecznie(bool sprawdzanieBłędów)
        {
            ZmiennaTypuListowego lista = new ZmiennaTypuListowego();

            foreach (WartośćWewnętrznegoKlockaZwracającegoWartość wartośćKlockaPrzyjmującegoWartość in Elementy)
            {
                KlocekZwracającyWartość klocekZwracającyWartość = wartośćKlockaPrzyjmującegoWartość[0];

                if (klocekZwracającyWartość != null)
                    lista.Add(klocekZwracającyWartość.Zwróć<object>(false));
            }

            return lista;
        }

        public override object Clone()
        {
            ListaZElementów kopia = (ListaZElementów) base.Clone();
            kopia.LiczbaElementów = LiczbaElementów;

            for (int i = 0; i < LiczbaElementów; i++)
            {
                WartośćWewnętrznegoKlockaZwracającegoWartość element = Elementy[i];
                var tmp = new WartośćWewnętrznegoKlockaZwracającegoWartość(element.PrzyjmowanyTyp) {[0] = (KlocekZwracającyWartość) element[0]?.Clone()};

                if (tmp[0] != null)
                    tmp[0].MiejsceUmieszczenia = tmp;

                kopia.Elementy[i] = tmp;
            }

            return kopia;
        }
    }
}