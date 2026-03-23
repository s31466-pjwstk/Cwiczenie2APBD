namespace Cwiczenie2APBD;

public class Serwis
{
    public static bool WarunekWypozyczenia(UzytkownikSystemu osoba)
    {
        return ((osoba.getRodzajUzytkownika() == RodzajUzytkownika.Student && Wypozyczenie.getAktywneWypozyczenia(osoba).Count() < 2) ||
         (osoba.getRodzajUzytkownika() == RodzajUzytkownika.Pracownik && Wypozyczenie.getAktywneWypozyczenia(osoba).Count() < 5));
    }

    public static double WyliczOplate(TimeSpan ts)
    {
        switch (ts.Days)
        {
            case <= 0:
                return 0.0;
            case > 0 and <=30:
                return ts.Days * 0.5;
            case > 30:
                return ts.Days * 1.0;
        }
    }

    public static DateTime OkresDarmowegoWypozyczenia(DateTime d) { return d.AddDays(14); }
}