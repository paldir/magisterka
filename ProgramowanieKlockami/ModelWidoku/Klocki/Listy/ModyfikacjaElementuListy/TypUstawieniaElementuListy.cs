namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.ModyfikacjaElementuListy
{
    public abstract class TypUstawieniaElementuListy
    {
        public abstract string ReprezentacjaTekstowa { get; }

        public abstract void ModyfikujListę(ZmiennaTypuListowego lista, int indeks, object wartość);

        public override bool Equals(object obj) => GetType() == obj.GetType();
        public override int GetHashCode() => ReprezentacjaTekstowa[0];
    }
}