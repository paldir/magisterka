using System;
using System.Windows;
using GongSolutions.Wpf.DragDrop;
using ProgramowanieKlockami.ModelWidoku.Klocki;
using ProgramowanieKlockami.ModelWidoku.PrzechowywanieStanuAplikacji;

namespace ProgramowanieKlockami.ModelWidoku.PrzeciągnijIUpuść
{
    public class ObsługującyUpuszczanieKlockówPionowych : IDropTarget
    {
        private readonly Action<ManipulacjaKlockiem> _metodaZachowującaStanAplikacji;

        public ObsługującyUpuszczanieKlockówPionowych(Action<ManipulacjaKlockiem> metodaZachowującaStanAplikacji)
        {
            _metodaZachowującaStanAplikacji = metodaZachowującaStanAplikacji;
        }

        public void DragOver(IDropInfo dropInfo)
        {
            KlocekPionowy upuszczanyKlocek = dropInfo.Data as KlocekPionowy;
            DragDropEffects efektUpuszczenia;

            if (upuszczanyKlocek == null)
                efektUpuszczenia = DragDropEffects.None;
            else
            {
                efektUpuszczenia = upuszczanyKlocek.ZPrzybornika ? DragDropEffects.Copy : DragDropEffects.Move;
                dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            }

            dropInfo.Effects = efektUpuszczenia;
        }

        public void Drop(IDropInfo dropInfo)
        {
            ZawartośćKlockaPionowegoZZawartością docelowaKolekcja = (ZawartośćKlockaPionowegoZZawartością) dropInfo.TargetCollection;
            KlocekPionowy upuszczanyKlocek = (KlocekPionowy) dropInfo.Data;
            upuszczanyKlocek.Rodzic = docelowaKolekcja.KlocekPionowyZZawartością;
            upuszczanyKlocek.ZPrzybornika = false;
            int indeks = dropInfo.InsertIndex;

            docelowaKolekcja.Insert(indeks, upuszczanyKlocek);
            _metodaZachowującaStanAplikacji(new ManipulacjaKlockiem(ManipulacjeKlockiem.Dodanie, upuszczanyKlocek, indeks));
        }
    }
}