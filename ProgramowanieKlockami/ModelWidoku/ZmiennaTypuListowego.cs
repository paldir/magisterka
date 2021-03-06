﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class ZmiennaTypuListowego : ObservableCollection<object>, IComparable
    {
        public ZmiennaTypuListowego()
        {
        }

        public ZmiennaTypuListowego(IEnumerable<object> kolekcja) : base(kolekcja)
        {
        }

        public override string ToString() => $"[{string.Join("; ", this)}]";

        public int CompareTo(object obj)
        {
            ZmiennaTypuListowego zmiennaTypuListowego = obj as ZmiennaTypuListowego;

            if (zmiennaTypuListowego == null)
                return 1;

            return this.SequenceEqual(zmiennaTypuListowego) ? 0 : Count.CompareTo(zmiennaTypuListowego.Count);
        }
    }
}