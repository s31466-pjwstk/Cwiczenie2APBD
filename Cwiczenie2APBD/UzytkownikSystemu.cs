namespace Cwiczenie2APBD;

public class UzytkownikSystemu
{
    private int id;
    private int uzytkownicy;
    RodzajUzytkownika rodzajUzytkownika;
    private string imie;
    private string Nazwisko;

    public UzytkownikSystemu(RodzajUzytkownika rodzajUzytkownika, string imie, string Nazwisko)
    {
        this.rodzajUzytkownika = rodzajUzytkownika;
        this.imie = imie;
        this.Nazwisko = Nazwisko;
        this.id = uzytkownicy+1;
        uzytkownicy++;
    }

    public override string ToString()
    {
        return imie + " " + Nazwisko;
    }
}