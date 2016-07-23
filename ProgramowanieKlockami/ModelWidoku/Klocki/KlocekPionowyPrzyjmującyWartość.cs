using System;
using System.Collections.ObjectModel;
using ProgramowanieKlockami.ModelWidoku.Debugowanie;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyPrzyjmującyWartość : KlocekPionowy
    {
        public WartośćWewnętrznegoKlockaZwracającegoWartość Wartość { get; }

        protected KlocekPionowyPrzyjmującyWartość(Type przyjmowanyTyp)
        {
            Wartość = new WartośćWewnętrznegoKlockaZwracającegoWartość(przyjmowanyTyp);
        }

        public override object Clone()
        {
            KlocekPionowyPrzyjmującyWartość kopia = (KlocekPionowyPrzyjmującyWartość) base.Clone();
            kopia.Wartość[0] = (KlocekZwracającyWartość) Wartość[0]?.Clone();

            return kopia;
        }

        public override void Wykonaj()
        {
            Błędy = new ObservableCollection<BłądKlocka>();
            Błędy.CollectionChanged += BłędyKonfiguracji_CollectionChanged;
            Błąd = false;
            Type oczekiwanyTyp = Wartość.PrzyjmowanyTyp;
            Type umieszczonyTyp = Wartość[0]?.Zwróć<object>().GetType();

            if (!oczekiwanyTyp.IsAssignableFrom(umieszczonyTyp))
                Błędy.Add(new BłądKlockaUmieszczonegoWewnątrzLubPodłączonego
                {
                    OczekiwanyTyp = oczekiwanyTyp,
                    UmieszczonyTyp = umieszczonyTyp
                });
        }

        private void BłędyKonfiguracji_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Błąd = Błędy.Count != 0;
        }
    }
}