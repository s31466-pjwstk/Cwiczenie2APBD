namespace Cwiczenie2APBD;


public class Sprzet
{
    int liczbaSprzetow;
    private int id;
    private String nazwa;
    private bool czyDostepny;
    
    public Sprzet()
    {
        id = liczbaSprzetow + 1;
        liczbaSprzetow++;
    }
    
}