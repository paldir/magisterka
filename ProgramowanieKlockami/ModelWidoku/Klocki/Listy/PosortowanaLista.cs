using System;
using ProgramowanieKlockami.ModelWidoku.Klocki.Listy.PorządkiSortowaniaListy;
using ProgramowanieKlockami.ModelWidoku.Klocki.Listy.SortowanieListy;

namespace ProgramowanieKlockami.ModelWidoku.Klocki.Listy
{
    public class PosortowanaLista : KlocekZwracającyWartośćPrzyjmującyWartość
    {
        public override string Nazwa => "Posortowana lista";
        public override string Opis => "Zwraca posortowaną kopię listy.";
        public override Type ZwracanyTyp => typeof(ZmiennaTypuListowego);

        public IPorządekSortowania WybranyPorządekSortowania { get; set; }
        public ISposóbSortowaniaListy WybranySposóbSortowania { get; set; }

        public PosortowanaLista() : base(typeof(ZmiennaTypuListowego))
        {
            Kolor = Kolory.Listy;
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
            ZmiennaTypuListowego lista = Wartość.Zwróć<ZmiennaTypuListowego>();

            return WybranySposóbSortowania.Uporządkuj(lista, WybranyPorządekSortowania.Rosnąco);
        }
    }
}