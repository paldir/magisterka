using System;
using System.Windows.Input;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Komenda : ICommand
    {
        private readonly Action _akcja;
        private readonly Action<object> _akcjaZParametrem;
        private Func<object, bool> _możnaWykonać;

        /// <summary>
        /// Relikt przeszłości
        /// </summary>
        private Func<object, bool> MożnaWykonać
        {
            get { return _możnaWykonać; }

            set
            {
                _możnaWykonać = value;

                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }

        public Komenda(Action akcja)
        {
            _akcja = akcja;
            MożnaWykonać = a => true;
        }

        public Komenda(Action<object> akcja)
        {
            _akcjaZParametrem = akcja;
            MożnaWykonać = a => true;
        }

        public bool CanExecute(object parameter)
        {
            return MożnaWykonać(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (_akcja != null)
                _akcja();
            else
                _akcjaZParametrem(parameter);
        }
    }
}