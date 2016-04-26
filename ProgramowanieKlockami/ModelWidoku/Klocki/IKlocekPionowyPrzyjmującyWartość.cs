namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public interface IKlocekPionowyPrzyjmującyWartość : IKlocekPionowy
    {
        IKlocekZwracającyWartość Wartość { get; set; }
    }
}