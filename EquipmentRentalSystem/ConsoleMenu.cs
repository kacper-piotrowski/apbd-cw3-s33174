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
        string userInputStr = "";
        while (userInput != 0)
        {
            Console.Clear();
            ShowMenu();
            userInputStr = Console.ReadLine();
            if (int.TryParse(userInputStr, out userInput))
            {
                switch (userInput)
                {
                    case 0:
                        break;
                    case 1:
                        AddUser();
                        break;
                    case 2:
                        AddEquipment();
                        break;
                    case 3:
                        PrintEquipment();
                        break;
                    default:
                        Console.WriteLine("To nie jest poprawna opcja!");
                        break;
                        
                }
            }
            else
            {
                Console.WriteLine("To nie jest poprawna opcja!");
                Console.ReadKey();
            }
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
    
    private void AddUser()
    {
        Console.Clear();
        string name;
        string surname;
        int choice;
        UserType userType = UserType.Student;
        Console.WriteLine("Podaj Imie");
        name = Console.ReadLine();
        Console.WriteLine("Podaj Nazwisko");
        surname = Console.ReadLine();
        Console.WriteLine("Kto to?");
        Console.WriteLine("1. Student");
        Console.WriteLine("2. Pracownik");
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            if (choice == 1)
            {
                userType = UserType.Student;
            }
            else if (choice == 2)
            {
                userType = UserType.Employee;
            }
            else
            {
                Console.WriteLine("Nie poprawna opcja!");
                Console.ReadKey();
                return;
            }
        }
        else
        {
            Console.WriteLine("Nie poprawna opcja!");
            Console.ReadKey();
            return;
        }

        User userNew = new User(name, surname, userType);
        
        _rentalService.AddUser(userNew);
        
        Console.WriteLine("Dodano użytkownika!");
        Console.ReadKey();
    }
    
    private void AddEquipment()
    {
        Console.Clear();
        string name;
        string department;
        bool isAvailable = true;
        int choice;
        Console.WriteLine("Podaj Nazwe");
        name = Console.ReadLine();
        Console.WriteLine("Podaj Wydział");
        department = Console.ReadLine();
        Console.WriteLine("Czy sprzęt jest dostępny?");
        Console.WriteLine("1. Tak");
        Console.WriteLine("2. Nie");
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            if (choice == 1)
            {
                isAvailable = true;
            }
            else if (choice == 2)
            {
                isAvailable = false;
            }
            else
            {
                return;
            }
        }
        Console.WriteLine("Co to?");
        Console.WriteLine("1. Laptop");
        Console.WriteLine("2. Aparat");
        Console.WriteLine("3. Projektor");
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            if (choice == 1)
            {
                string processor;
                string graphicsCard;
                Console.WriteLine("Podaj procesor: ");
                processor = Console.ReadLine();
                Console.WriteLine("Podaj kartę graficzną: ");
                graphicsCard = Console.ReadLine();
                Laptop laptopNew = new Laptop(name,department,isAvailable, processor, graphicsCard);
                _rentalService.AddEquipment(laptopNew);
                Console.WriteLine("Dodano nowy laptop!");
                Console.ReadKey();
                
            }
            else if (choice == 2)
            {
                string lens;
                int batteries;
                Console.WriteLine("Podaj obiektyw: ");
                lens = Console.ReadLine();
                Console.WriteLine("Podaj liczbe baterii: ");
                batteries = int.Parse(Console.ReadLine());
                Camera cameraNew = new Camera(name,department,isAvailable, lens, batteries);
                _rentalService.AddEquipment(cameraNew);
                Console.WriteLine("Dodano nowy aparat!");
                Console.ReadKey();
            }
            else if  (choice == 3)
            {
                string resolution;
                string brightness;
                Console.WriteLine("Podaj rozdzielczość: ");
                resolution = Console.ReadLine();
                Console.WriteLine("Podaj jasność: ");
                brightness = Console.ReadLine();
                Projector projectorNew = new Projector(name,department,isAvailable, resolution, brightness);
                _rentalService.AddEquipment(projectorNew);
                Console.WriteLine("Dodano nowy projektor!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Nie poprawna opcja!");
                Console.ReadKey();
                return;
            }
        }
        else
        {
            Console.WriteLine("Nie poprawna opcja!");
            Console.ReadKey();
            return;
        }
        
    }
    
    private void PrintEquipment()
    {
        Console.Clear();
        for (int i = 0; i < _rentalService.EquipmentList.Count(); i++)
        {
            Console.WriteLine(_rentalService.EquipmentList[i]);
        }
        Console.ReadKey();
    }
}