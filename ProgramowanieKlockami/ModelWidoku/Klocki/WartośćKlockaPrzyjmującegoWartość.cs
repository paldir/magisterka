using System;
using System.Collections.ObjectModel;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public class WartośćKlockaPrzyjmującegoWartość : ObservableCollection<KlocekZwracającyWartość>
    {
        public Type PrzyjmowanyTyp { get; }

        public WartośćKlockaPrzyjmującegoWartość(Type przyjmowanyTyp)
        {
            PrzyjmowanyTyp = przyjmowanyTyp;

            Add(null);
        }
    }
}