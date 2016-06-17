using ProgramowanieKlockami.ModelWidoku.Klocki.KonfiguracjaKlocków.KonfiguracjaKlockówZwracającychWartość;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Logika.StałeLogiczne
{
    public class Prawda : IOpcjaZwracającaWartość<bool>
    {
        public string ReprezentacjaTekstowa => "prawda";
        public bool Wartość => true;
    }
}