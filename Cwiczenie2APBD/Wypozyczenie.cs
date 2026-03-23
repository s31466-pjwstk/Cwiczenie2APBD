namespace Cwiczenie2APBD;

public class Wypozyczenie
{
    private UzytkownikSystemu osoba;
    private Sprzet sprzet;
    private DateTime dataWypozyczenia;
    private DateTime oczekiwanaDataZwrotu;
    private DateTime rzeczywistaDataZwrotu;
    private double oplata;
    private bool? czyZwrotTerminowy = null;
    private static List<Wypozyczenie> wypozyczenia = new List<Wypozyczenie>();
    private static double zarobek;

    public Wypozyczenie(UzytkownikSystemu osoba, Sprzet sprzet, DateTime dataWypozyczenia)
    {
        try
        {
            if(Serwis.WarunekWypozyczenia(osoba))
            {
                if (sprzet.getDostepnosc() == true)
                {
                    this.osoba = osoba;
                    this.sprzet = sprzet;
                    this.dataWypozyczenia = dataWypozyczenia;
                    this.oczekiwanaDataZwrotu = Serwis.OkresDarmowegoWypozyczenia(dataWypozyczenia);
                    wypozyczenia.Add(this);
                    sprzet.ustawCzyDostepny(false);
                    Console.WriteLine($"Wyporzyczono {sprzet} przez {osoba}");
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

    public void ZwrotSprzetu(DateTime dataZwrotu)
    {
        rzeczywistaDataZwrotu = dataZwrotu;
        TimeSpan ts = rzeczywistaDataZwrotu - oczekiwanaDataZwrotu;
        if (rzeczywistaDataZwrotu == oczekiwanaDataZwrotu || ts.Days < 1)
        {
            oplata = Serwis.WyliczOplate(ts);
            zarobek = zarobek + oplata;
            czyZwrotTerminowy = true;
            sprzet.ustawCzyDostepny(true);
            Console.WriteLine($"Zwrot w termine. Oplata wynosi: {oplata} PLN");
        }
        else
        {
            oplata = Serwis.WyliczOplate(ts);
            zarobek = zarobek + oplata;
            czyZwrotTerminowy = false;
            Console.WriteLine($"Zwrot po terminie! Oplata wynosi: {oplata} PLN");
        }
    }

    public static List<Wypozyczenie> getAktywneWypozyczenia(UzytkownikSystemu osoba)
    {
        List<Wypozyczenie> listaWyporzyczen = new List<Wypozyczenie>();
        foreach (Wypozyczenie w in wypozyczenia)
        {
            if (w.osoba == osoba && w.czyZwrotTerminowy == null)
                listaWyporzyczen.Add(w);
        }
        return listaWyporzyczen;
    }
    
    public static void PrintAktywneWypozyczenia(UzytkownikSystemu osoba)
    {
        foreach (Wypozyczenie w in wypozyczenia)
        {
            if (w.osoba == osoba && w.czyZwrotTerminowy == null)
                Console.WriteLine(w);
        }
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
                {
                    listaWyporzyczen.Add(w);
                    Console.WriteLine(w);
                }
            }
        }
        return listaWyporzyczen;
    }

    public static List<Wypozyczenie> StanWypozyczalni()
    {
        List<Wypozyczenie> listaWyporzyczen = new List<Wypozyczenie>();
        Console.WriteLine("Wszystkie aktywne wypozyczenia: ");
        foreach (Wypozyczenie w in wypozyczenia)
        {
            if (w.czyZwrotTerminowy == null)
            {
                listaWyporzyczen.Add(w);
                Console.WriteLine(w);
            }
        }
        Console.WriteLine($"Łącznie aktywnych wypozyczeń: {listaWyporzyczen.Count} ");
        Console.WriteLine($"Aktualny zarobek ze zwrotów po terminie {zarobek} PLN");
        return listaWyporzyczen;
    }
    
    public override string ToString() { return $"{osoba} wypozyczyl/a {sprzet} | Termin oddania to: {oczekiwanaDataZwrotu}"; }
}