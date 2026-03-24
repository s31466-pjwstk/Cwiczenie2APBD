namespace Cwiczenie2APBD;

public class UzytkownikSystemu
{
    private int id;
    private static int uzytkownicy;
    private RodzajUzytkownika rodzajUzytkownika;
    private string imie;
    private string nazwisko;

    public UzytkownikSystemu(RodzajUzytkownika rodzajUzytkownika, string imie, string nazwisko)
    {
        this.rodzajUzytkownika = rodzajUzytkownika;
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.id = uzytkownicy+1;
        uzytkownicy++;
    }

    public RodzajUzytkownika getRodzajUzytkownika() { return this.rodzajUzytkownika; }
    public override string ToString() { return imie + " " + nazwisko; }
}