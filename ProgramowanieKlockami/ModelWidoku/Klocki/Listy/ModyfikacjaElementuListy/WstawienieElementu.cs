namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy.ModyfikacjaElementuListy
{
    public class WstawienieElementu : TypUstawieniaElementuListy
    {
        public override string ReprezentacjaTekstowa => "wstaw element na pozycję nr";

        public override void ModyfikujListę(ZmiennaTypuListowego lista, int indeks, object wartość)
        {
            for (int i = lista.Count - 1; i < indeks - 1; i++)
                lista.Add(null);

            if (indeks >= 0)
                lista.Insert(indeks, wartość);
        }
    }
}