using System;

namespace ProgramowanieKlockami.ModelWidoku.Klocki
{
    public abstract class KlocekZwracającyWartość : Klocek
    {
        public abstract Type ZwracanyTyp { get; }

        public WartośćWewnętrznegoKlockaZwracającegoWartość MiejsceUmieszczenia { get; set; }

        private object Zwróć(bool sprawdzanieBłędów)
        {
            SprawdźPoprawnośćKlockówKonfigurujących();

            if (Błąd)
            {
                if (ZwracanyTyp == null)
                    return null;

                return ZwracanyTyp == typeof(object) ? string.Empty : Activator.CreateInstance(ZwracanyTyp);
            }

            return ZwróćNiebezpiecznie(sprawdzanieBłędów);
        }

        protected abstract object ZwróćNiebezpiecznie(bool sprawdzanieBłędów);

        public T Zwróć<T>(bool sprawdzanieBłędów)
        {
            object zwróconaWartość = Zwróć(sprawdzanieBłędów);
            Type typDocelowy = typeof(T);

            if (zwróconaWartość != null)
            {
                if (typDocelowy.IsInstanceOfType(zwróconaWartość))
                    return (T) zwróconaWartość;

                try
                {
                    return (T) Convert.ChangeType(zwróconaWartość, typDocelowy);
                }
                catch (Exception)
                {
                }
            }

            return Activator.CreateInstance<T>();
        }

        public override object Clone()
        {
            KlocekZwracającyWartość kopia = (KlocekZwracającyWartość) base.Clone();
            kopia.MiejsceUmieszczenia = MiejsceUmieszczenia;

            return kopia;
        }
    }
}