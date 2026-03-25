namespace EquipmentRentalSystem;

public class ConsoleMenu
{
    private RentalService _rentalService;

    public ConsoleMenu(RentalService rentalService)
    {
        _rentalService = rentalService;
    }

    public void Run()
    {
        int userInput = -1;
        while (userInput != 0)
        {
            ShowMenu();
            userInput = Console.Read();
        }
    }

    private void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Co chcesz zrobić?");
        Console.WriteLine("0. Wyjdź");
        Console.WriteLine("1. Dodaj nowego użytkownika do systemu.");
        Console.WriteLine("2. Dodaj nowegy sprzęt do systemu.");
        Console.WriteLine("3. Wyświetl liste całego sprzętu z aktualnym statusem.");
        Console.WriteLine("4. Wyświetl sprzęt dostępny do wypożyczenia.");
        Console.WriteLine("5. Wypożycz sprzęt użytkownikowi.");
        Console.WriteLine("6. Zwróć sprzęt.");
        Console.WriteLine("7. Zmień status dostępności sprzętu.");
        Console.WriteLine("8. Wyświetl aktywne wypożyczenia danego użytkownika.");
        Console.WriteLine("9. Wyświetl listę przeterminowanych wypożyczeń.");
        Console.WriteLine("10. Wyświetl raport biznesowy.");
    }
}