namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.StałeLogiczne
{
    public class Fałsz : IStałaLogiczna
    {
        public string ReprezentacjaTekstowa => "fałsz";
        public bool WartośćLogiczna => false;
    }
}