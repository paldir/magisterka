using System;
using System.Windows;
using GongSolutions.Wpf.DragDrop;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekPionowy : Klocek
    {
        private KlocekPionowy _następny;

        public KlocekPionowy Następny
        {
            get { return _następny; }

            set
            {
                _następny = value;

                OnPropertyChanged();
            }
        }
    }
}