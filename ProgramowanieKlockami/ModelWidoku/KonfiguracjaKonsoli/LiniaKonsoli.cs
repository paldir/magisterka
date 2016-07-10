using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProgramowanieKlockami.ModelWidoku.KonfiguracjaKonsoli
{
    public class LiniaKonsoli : INotifyPropertyChanged
    {
        private bool _edytowalna;

        public Komenda KomendaWyłączeniaEdytowalności { get; }

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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}