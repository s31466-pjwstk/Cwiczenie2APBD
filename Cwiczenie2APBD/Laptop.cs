namespace Cwiczenie2APBD;

public class Laptop : Sprzet
{
    private double pamiec;
    private double iloscRAM;
    private string OS;

    public Laptop(string nazwa, string producent, double pamiec, double iloscRAM, string OS) : base(nazwa, producent)
    {
        this.pamiec = pamiec;
        this.iloscRAM = iloscRAM;
        this.OS = OS;
    }
}