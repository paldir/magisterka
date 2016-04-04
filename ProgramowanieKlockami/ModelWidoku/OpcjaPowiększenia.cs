namespace ProgramowanieKlockami.ModelWidoku
{
    public class OpcjaPowiększenia
    {
        public string Etykieta { get; set; }
        public double Powiększenie { get; set; }

        public OpcjaPowiększenia(double powiększenie)
        {
            Powiększenie = powiększenie;
            Etykieta = $"{powiększenie*100}%";
        }
    }
}