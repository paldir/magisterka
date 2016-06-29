using System;
using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public class WartośćWewnętrznegoKlockaZwracającegoWartość : ObservableCollection<KlocekZwracającyWartość>
    {
        public Type PrzyjmowanyTyp { get; }

        public WartośćWewnętrznegoKlockaZwracającegoWartość(Type przyjmowanyTyp)
        {
            PrzyjmowanyTyp = przyjmowanyTyp;

            Add(null);
        }

        public T Zwróć<T>()
        {
            return this[0].Zwróć<T>();
        }
    }
}