namespace Cwiczenie2APBD;

public class Wypozyczenie
{
    private UzytkownikSystemu osoba;
    Sprzet sprzet;
    private DateTime dataWypozyczenia;
    TimeSpan okresWypozyczenia = TimeSpan.FromDays(14);
    DateTime oczekiwanaDataZwrotu;
    DateTime rzeczywistaDataZwrotu;
    private double oplata;
    private bool? czyZwrotTerminowy = null;
    private static List<Wypozyczenie> wypozyczenia = new List<Wypozyczenie>();

    public Wypozyczenie(UzytkownikSystemu osoba, Sprzet sprzet, DateTime dataWypozyczenia)
    {
        this.osoba = osoba;
        this.sprzet = sprzet;
        this.dataWypozyczenia = dataWypozyczenia;
        this.oczekiwanaDataZwrotu = dataWypozyczenia + okresWypozyczenia;
        wypozyczenia.Add(this);
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
            oplata = ts.Days * 0.5;
            czyZwrotTerminowy = false;
            return $"Oplata wynosi: {oplata} PLN";
        }
    }

    public static void aktywneWypozyczenia(UzytkownikSystemu osoba)
    {
        foreach (Wypozyczenie w in wypozyczenia)
        {
            if( w.osoba == osoba && w.czyZwrotTerminowy==null)
                Console.WriteLine(w);
        }
    }
    
    public static void przeterminowaneWypozyczenia(UzytkownikSystemu osoba)
    {
        foreach (Wypozyczenie w in wypozyczenia)
        {
            if (w.osoba == osoba && w.czyZwrotTerminowy==null)
            {
                TimeSpan ts = w.oczekiwanaDataZwrotu - DateTime.Now;
                if (ts.Days < 0)
                    Console.WriteLine(w + " (PO TERMINIE!!!)");
            }
        }
    }

    public static void stanWypozyczalni()
    {
        Console.WriteLine("Wszystkie aktualne wypozyczenia: ");
        foreach (Wypozyczenie w in wypozyczenia)
        {
            if(w.czyZwrotTerminowy==null)
                Console.WriteLine(w);
        }
    }
    public override string ToString()
    {
        return $"{osoba} wypozyczyl/a {sprzet} | Termin oddania to: {oczekiwanaDataZwrotu}";
    }
}