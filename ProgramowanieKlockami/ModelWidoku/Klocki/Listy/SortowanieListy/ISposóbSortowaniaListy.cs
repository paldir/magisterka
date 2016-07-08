namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.SortowanieListy
{
    public interface ISposóbSortowaniaListy
    {
        string ReprezentacjaTekstowa { get; }

        ZmiennaTypuListowego Uporządkuj(ZmiennaTypuListowego lista, bool rosnąco);
    }
}