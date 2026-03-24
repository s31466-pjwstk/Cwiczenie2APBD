

using System.Globalization;
using Cwiczenie2APBD;

//Próbne sprzety
Sprzet s1 = new Sprzet("Odkurzacz1", "Dyson");
Sprzet s2 = new Sprzet("Odkurzacz2", "Dyson");
Kamera k1 = new Kamera("Lustrzanka1","Sony",120,"FullHD");
Kamera k2 = new Kamera("Lustrzanka2","Cannon",140,"4K");
Kamera k3 = new Kamera("Lustrzanka3","Nikon",60,"720p");
Laptop l1 = new Laptop("Laptop1", "DELL", 1000.0, 16.0, "Windows");
Laptop l2 = new Laptop("Laptop2", "HP", 1500.0, 32.0, "Linux");
Laptop l3 = new Laptop("Laptop3", "Apple", 500.0, 8.0, "MacOS");
Projektor p1 = new Projektor("Projektor1", "Samsung", 230, "DLP");
Projektor p2 = new Projektor("Projektor2", "OPTOMA", 650, "Laser");
Projektor p3 = new Projektor("Projektor3", "Dangbei", 450, "DLP");

UzytkownikSystemu student1 = new UzytkownikSystemu(RodzajUzytkownika.Student, "Adam", "Kowalski");
UzytkownikSystemu student2 = new UzytkownikSystemu(RodzajUzytkownika.Student, "Agnieszka", "Nowak");
UzytkownikSystemu pracownik1 = new UzytkownikSystemu(RodzajUzytkownika.Pracownik, "Oskar", "Lewandowski");

Wypozyczenie wypozyczenie1 = new Wypozyczenie(student1, k1, new DateTime(2026,02,01, new GregorianCalendar()));
Wypozyczenie wypozyczenie2 = new Wypozyczenie(student1, s1, new DateTime(2026,03,01, new GregorianCalendar()));
Wypozyczenie wypozyczenie3 = new Wypozyczenie(student2, s2, new DateTime(2026,03,01, new GregorianCalendar()));
Wypozyczenie wypozyczenie4 = new Wypozyczenie(student2, k2, new DateTime(2026,03,01, new GregorianCalendar()));
Wypozyczenie wypozyczenie5 = new Wypozyczenie(pracownik1, k3, new DateTime(2026,03,01, new GregorianCalendar()));
Wypozyczenie wypozyczenie6 = new Wypozyczenie(pracownik1, p2, new DateTime(2026,03,01, new GregorianCalendar()));
Console.WriteLine("");

//Przekroczenie limitu wypozyczen dla studenta
Wypozyczenie wypozyczenie7 = new Wypozyczenie(student1, p1, new DateTime(2026,03,01, new GregorianCalendar()));
Console.WriteLine("");

//Proba wypozyczenia niedostepnego przedmiotu
Wypozyczenie wypozyczenie8 = new Wypozyczenie(student2, k1, new DateTime(2026,03,01, new GregorianCalendar()));
Console.WriteLine("");

//Zwrot sprzetu w terminie
wypozyczenie1.ZwrotSprzetu(new DateTime(2026,02,02));
Console.WriteLine("");

//Zwrot przeterminowany
wypozyczenie2.ZwrotSprzetu(new DateTime(2026,03,25));
Console.WriteLine("");

//Stan wypozyczlni
Wypozyczenie.StanWypozyczalni();

