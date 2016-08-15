namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.SortowanieListy
{
    public abstract class SposóbSortowaniaListy
    {
        public abstract string ReprezentacjaTekstowa { get; }

        public abstract ZmiennaTypuListowego Uporządkuj(ZmiennaTypuListowego lista, bool rosnąco);

        public override bool Equals(object obj) => GetType() == obj.GetType();
        public override int GetHashCode() => ReprezentacjaTekstowa[0];
    }
}