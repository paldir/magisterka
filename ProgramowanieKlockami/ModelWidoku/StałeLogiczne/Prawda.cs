namespace ProgramowanieKlockami.ModelWidoku.StałeLogiczne
{
    public class Prawda : IStałaLogiczna
    {
        public string ReprezentacjaTekstowa => "prawda";
        public bool WartośćLogiczna => true;
    }
}