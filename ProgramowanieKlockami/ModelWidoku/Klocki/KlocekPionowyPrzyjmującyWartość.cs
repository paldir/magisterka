using System.Windows.Media;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowyPrzyjmującyWartość : IKlocekPionowyPrzyjmującyWartość
    {
        public abstract string Nazwa { get; }
        public abstract string Opis { get; }
        public abstract Brush Kolor { get; }
        public IKlocekZwracającyWartość Wartość { get; set; }
    }
}