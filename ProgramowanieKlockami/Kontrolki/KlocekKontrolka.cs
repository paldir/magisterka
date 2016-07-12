using System.Windows.Controls;
using ProgramowanieKlockami.ModelWidoku.Klocki;

namespace ProgramowanieKlockami.Kontrolki
{
    public abstract class KlocekKontrolka<T> : ContentControl where T : Klocek
    {
        private T _kontekst;

        public T Kontekst
        {
            get
            {
                T kontekst = DataContext as T;

                if (kontekst == null)
                    DataContext = _kontekst;

                return (T) DataContext;
            }
        }

        protected KlocekKontrolka()
        {
            DataContextChanged += KlocekKontrolka_DataContextChanged;
        }

        private void KlocekKontrolka_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            T kontekst = DataContext as T;

            if (kontekst != null)
                _kontekst = kontekst;
        }
    }
}