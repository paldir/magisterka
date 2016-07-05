using System;
using System.Collections.Generic;
using System.Windows.Media;
using ProgramowanieKlockami.ModelWidoku.Klocki.Listy.PorządkiSortowaniaListy;
using ProgramowanieKlockami.ModelWidoku.Klocki.Listy.SposobySortowaniaListy;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class PosortowanaLista : KlocekZwracającyWartośćPrzyjmującyWartość
    {
        public override Brush Kolor => Kolory.Listy;
        public override string Nazwa => "Posortowana lista";
        public override string Opis => "Zwraca posortowaną kopię listy.";
        public override Type ZwracanyTyp => typeof(List<object>);

        public IPorządekSortowania WybranyPorządekSortowania { get; set; }
        public ISposóbSortowaniaListy WybranySposóbSortowania { get; set; }

        public PosortowanaLista() : base(typeof(List<object>))
        {
        }

        public override object Clone()
        {
            PosortowanaLista kopia = (PosortowanaLista) base.Clone();
            kopia.WybranyPorządekSortowania = WybranyPorządekSortowania;
            kopia.WybranySposóbSortowania = WybranySposóbSortowania;

            return kopia;
        }

        protected override object ZwróćNiebezpiecznie()
        {
            List<object> lista = Wartość.Zwróć<List<object>>();

            return WybranySposóbSortowania.Uporządkuj(lista, WybranyPorządekSortowania.Rosnąco);
        }
    }
}