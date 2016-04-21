﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ProgramowanieKlockami.ModelWidoku.Klocki;
using ProgramowanieKlockami.ModelWidoku.Klocki.Inne;
using ProgramowanieKlockami.ModelWidoku.Klocki.Logika;
using ProgramowanieKlockami.ModelWidoku.Klocki.Tekst;
using ProgramowanieKlockami.ModelWidoku.Klocki.Zmienne;

namespace ProgramowanieKlockami.ModelWidoku
{
    public class Główny : INotifyPropertyChanged
    {
        public KlocekPionowy[] KlockiPionowe { get; }
        public ObservableCollection<KlocekZwracającyWartość> KlockiZwracająceWartość { get; }
        public RozpoczęcieProgramu RozpoczęcieProgramu { get; }
        public ObservableCollection<Zmienna> Zmienne { get; }
        public Komenda KomendaDodaniaZmiennej { get; }
        public Komenda KomendaUsunięciaZmiennej { get; }
        public Klocek Test { get; }
        public IEnumerable<Klocek> KlockiLogiczne { get; } 
        public IEnumerable<Klocek> KlockiTekstowe { get; }
        public IEnumerable<Klocek> KlockiDotycząceZmiennych { get; }

        private string _nazwaNowejZmiennej;

        public string NazwaNowejZmiennej
        {
            get { return _nazwaNowejZmiennej; }

            set
            {
                _nazwaNowejZmiennej = value;

                OnPropertyChanged();
            }
        }

        private double _powiększenie;

        public double Powiększenie
        {
            get { return _powiększenie; }

            set
            {
                _powiększenie = value;

                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Główny()
        {
            KlockiPionowe = new KlocekPionowy[0];

            KlockiZwracająceWartość = new ObservableCollection<KlocekZwracającyWartość>
            {
                new Porównanie(),
                new Napis(),
                new WartośćZmiennej()
            };

            KlockiLogiczne = new Klocek[]
            {
                new Jeżeli(),
                new Porównanie()
            };

            KlockiTekstowe = new Klocek[]
            {
                new Napis(),
                new Wyświetl()
            };

            KlockiDotycząceZmiennych = new Klocek[]
            {
                new UstawZmienną(),
                new WartośćZmiennej()
            };

            RozpoczęcieProgramu = new RozpoczęcieProgramu();
            Zmienne = new ObservableCollection<Zmienna>();
            KomendaDodaniaZmiennej = new Komenda(DodajZmienną);
            KomendaUsunięciaZmiennej = new Komenda(UsuńZmienną);
            Test = new Porównanie();
            Powiększenie = 1;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DodajZmienną()
        {
            Zmienna zmienna = Zmienne.SingleOrDefault(z => z.Nazwa == NazwaNowejZmiennej);

            if (!string.IsNullOrEmpty(NazwaNowejZmiennej) && (zmienna == null))
            {
                Zmienne.Add(new Zmienna(Zmienne) { Nazwa = NazwaNowejZmiennej });

                NazwaNowejZmiennej = null;
            }
        }

        private void UsuńZmienną(object zmiennaDoUsunięcia)
        {
            Zmienna zmienna = zmiennaDoUsunięcia as Zmienna;

            if (zmienna != null)
                Zmienne.Remove(zmienna);
        }
    }
}