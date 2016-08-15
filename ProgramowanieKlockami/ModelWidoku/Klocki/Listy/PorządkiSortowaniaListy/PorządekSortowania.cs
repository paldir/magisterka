namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.PorządkiSortowaniaListy
{
    public abstract class PorządekSortowania
    {
        public abstract string ReprezentacjaTekstowa { get; }
        public abstract bool Rosnąco { get; }

        public override bool Equals(object obj) => GetType() == obj.GetType();
        public override int GetHashCode() => ReprezentacjaTekstowa[0];
    }
}