namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.ModyfikacjaElementuListy
{
    public interface ITypUstawieniaElementuListy
    {
        string ReprezentacjaTekstowa { get; }

        void ModyfikujListę(ZmiennaTypuListowego lista, int indeks, object wartość);
    }
}