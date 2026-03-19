// See https://aka.ms/new-console-template for more information

using System.Globalization;
using Cwiczenie2APBD;

//Próbne obiekty
Sprzet s = new Sprzet("Odkurzacz", "Dyson");
Kamera k = new Kamera("Lustrzanka","Sony",120,"FullHD");
UzytkownikSystemu student1 = new UzytkownikSystemu(RodzajUzytkownika.Student, "Adam", "Kowalski");
Wypozyczenie wypozyczenie1 = new Wypozyczenie(student1, k, new DateTime(2026,02,01, new GregorianCalendar()));
Wypozyczenie wypozyczenie2 = new Wypozyczenie(student1, s, new DateTime(2026,03,01, new GregorianCalendar()));

//Testowanie metod
/*
Console.WriteLine(wypozyczenie1.ZwrotSprzetu(new DateTime(2026,02,04, new GregorianCalendar())));
Wypozyczenie.aktywneWypozyczenia(student1);
Wypozyczenie.przeterminowaneWypozyczenia(student1);
Wypozyczenie.stanWypozyczalni();
Console.WriteLine(Sprzet.liczbaSprzetow);
k.ustawNieDostepny();
Sprzet.getListaSprzetow();
*/