using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ProgramowanieKlockami.ModelWidoku.KonfiguracjaKonsoli
{
    public class LiniaKonsoli : INotifyPropertyChanged
    {
        private bool _edytowalna;

        public Komenda KomendaWyłączeniaEdytowalności { get; }

        public AutoResetEvent Semafor { get; set; }

        public bool Edytowalna
        {
            get { return _edytowalna; }

            set
            {
                _edytowalna = value;

                OnPropertyChanged();
            }
        }

        public string Zawartość { get; set; }

        public LiniaKonsoli()
        {
            KomendaWyłączeniaEdytowalności = new Komenda(WyłączEdytowalność);
        }

        private void WyłączEdytowalność()
        {
            Edytowalna = false;

            Semafor?.Set();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}