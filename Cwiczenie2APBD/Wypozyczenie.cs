namespace Cwiczenie2APBD;

public class Wypozyczenie
{
    private UzytkownikSystemu osoba;
    private Sprzet sprzet;
    private DateTime dataWypozyczenia;
    private TimeSpan okresWypozyczenia = TimeSpan.FromDays(14);
    private DateTime oczekiwanaDataZwrotu;
    private DateTime rzeczywistaDataZwrotu;
    private double oplata;
    private bool? czyZwrotTerminowy = null;
    private static List<Wypozyczenie> wypozyczenia = new List<Wypozyczenie>();

    public Wypozyczenie(UzytkownikSystemu osoba, Sprzet sprzet, DateTime dataWypozyczenia)
    {
        try
        {
            if ((osoba.getRodzajUzytkownika() == RodzajUzytkownika.Student && Wypozyczenie.AktywneWypozyczenia(osoba).Count() < 2) ||
                (osoba.getRodzajUzytkownika() == RodzajUzytkownika.Pracownik && Wypozyczenie.AktywneWypozyczenia(osoba).Count() < 5))
            {
                if (sprzet.getDostepnosc() == true)
                {
                    this.osoba = osoba;
                    this.sprzet = sprzet;
                    this.dataWypozyczenia = dataWypozyczenia;
                    this.oczekiwanaDataZwrotu = dataWypozyczenia + okresWypozyczenia;
                    wypozyczenia.Add(this);
                }
                else
                    throw new SprzetNiedostepnyException("Ten sprzęt nie jest dostępny!");
            }
            else
                throw new ZaDuzoWyporzyczenException("Użytkownik posiada już dwa aktywne wypożyczenia!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public string ZwrotSprzetu(DateTime dataZwrotu)
    {
        rzeczywistaDataZwrotu = dataZwrotu;
        TimeSpan ts = rzeczywistaDataZwrotu - oczekiwanaDataZwrotu;
        if (rzeczywistaDataZwrotu == oczekiwanaDataZwrotu || ts.Days < 1)
        {
            oplata = 0.0;
            czyZwrotTerminowy = true;
            return $"Oplata wynosi: {oplata} PLN";
        }
        else
        {
            oplata = ts.Days * 0.5; //Reguła naliczania opłat
            czyZwrotTerminowy = false;
            return $"Oplata wynosi: {oplata} PLN";
        }
    }

    public static List<Wypozyczenie> AktywneWypozyczenia(UzytkownikSystemu osoba)
    {
        List<Wypozyczenie> listaWyporzyczen = new List<Wypozyczenie>();
        foreach (Wypozyczenie w in wypozyczenia)
        {
            if (w.osoba == osoba && w.czyZwrotTerminowy == null)
                listaWyporzyczen.Add(w);
        }
        return listaWyporzyczen;
    }
    
    public static List<Wypozyczenie> PrzeterminowaneWypozyczenia(UzytkownikSystemu osoba)
    {
        List<Wypozyczenie> listaWyporzyczen = new List<Wypozyczenie>();
        foreach (Wypozyczenie w in wypozyczenia)
        {
            if (w.osoba == osoba && w.czyZwrotTerminowy==null)
            {
                TimeSpan ts = w.oczekiwanaDataZwrotu - DateTime.Now;
                if (ts.Days < 0)
                    listaWyporzyczen.Add(w);
            }
        }
        return listaWyporzyczen;
    }

    public static List<Wypozyczenie> stanWypozyczalni()
    {
        List<Wypozyczenie> listaWyporzyczen = new List<Wypozyczenie>();
        Console.WriteLine("Wszystkie aktywne wypozyczenia: ");
        foreach (Wypozyczenie w in wypozyczenia)
        {
            if (w.czyZwrotTerminowy == null)
                listaWyporzyczen.Add(w);
        }
        return listaWyporzyczen;
    }
    
    public override string ToString() { return $"{osoba} wypozyczyl/a {sprzet} | Termin oddania to: {oczekiwanaDataZwrotu}"; }
}