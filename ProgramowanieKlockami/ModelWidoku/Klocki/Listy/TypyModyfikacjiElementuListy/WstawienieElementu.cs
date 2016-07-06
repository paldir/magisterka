namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.TypyModyfikacjiElementuListy
{
    public class WstawienieElementu : ITypUstawieniaElementuListy
    {
        public string ReprezentacjaTekstowa => "wstaw element na pozycję nr";

        public void ModyfikujListę(ZmiennaTypuListowego lista, int indeks, object wartość)
        {
            for (int i = lista.Count - 1; i < indeks - 1; i++)
                lista.Add(null);

            if (indeks >= 0)
                lista.Insert(indeks, wartość);
        }
    }
}