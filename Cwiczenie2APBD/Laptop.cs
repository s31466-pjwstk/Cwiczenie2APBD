namespace Cwiczenie2APBD;

public class Laptop : Sprzet
{
    private double pamiec;
    private double iloscRam;
    private string systemOperacyjny;

    public Laptop(string nazwa, string producent, double pamiec, double iloscRam, string systemOperacyjny) : base(nazwa, producent)
    {
        this.pamiec = pamiec;
        this.iloscRam = iloscRam;
        this.systemOperacyjny = systemOperacyjny;
    }
}