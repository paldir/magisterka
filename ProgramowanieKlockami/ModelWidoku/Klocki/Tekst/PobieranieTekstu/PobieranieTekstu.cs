namespace ProgramowanieKlockami.ModelWidoku.Klocki.Tekst.PobieranieTekstu
{
    public abstract class PobieranieTekstu
    {
        public abstract string ReprezentacjaTekstowa { get; }
        public abstract object WartośćDomyślna { get; }

        public abstract object Konwertuj(string x);

        public override bool Equals(object obj) => GetType() == obj.GetType();
        public override int GetHashCode() => ReprezentacjaTekstowa[0];
    }
}
