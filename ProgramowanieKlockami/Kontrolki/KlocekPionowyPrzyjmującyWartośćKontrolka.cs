using System.Windows;
using ProgramowanieKlockami.ModelWidoku;

namespace ProgramowanieKlockami.Kontrolki
{
    public abstract class KlocekPionowyPrzyjmującyWartośćKontrolka : KlocekPionowyKontrolka
    {
        public static readonly DependencyProperty WartośćProperty = DependencyProperty.Register(
            "Wartość", typeof (KlocekZwracającyWartość), typeof (KlocekPionowyPrzyjmującyWartośćKontrolka), new PropertyMetadata(default(KlocekZwracającyWartość)));

        public KlocekZwracającyWartość Wartość
        {
            get { return (KlocekZwracającyWartość) GetValue(WartośćProperty); }
            set { SetValue(WartośćProperty, value); }
        }
    }
}