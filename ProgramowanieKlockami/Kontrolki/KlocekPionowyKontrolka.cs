using System.Windows;
using System.Windows.Controls;
using ProgramowanieKlockami.ModelWidoku;

namespace ProgramowanieKlockami.Kontrolki
{
    public class KlocekPionowyKontrolka : UserControl
    {
        public static readonly DependencyProperty NastępnyProperty = DependencyProperty.Register(
            "Następny", typeof (KlocekPionowy), typeof (KlocekPionowyKontrolka), new PropertyMetadata(default(KlocekPionowy)));

        public KlocekPionowy Następny
        {
            get { return (KlocekPionowy) GetValue(NastępnyProperty); }
            set { SetValue(NastępnyProperty, value); }
        }
    }
}