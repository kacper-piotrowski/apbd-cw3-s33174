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
                    case 4:
                        PrintAvaiableEquipment();
                        break;
                    case 5:
                        PrintRenting();
                        break;
                    case 6:
                        PrintReturning();
                        break;
                    case 7:
                        PrintChangeStatus();
                        break;
                    case 8:
                        PrintUserRentals();
                        break;
                    case 9:
                        PrintOverduerRentals();
                        break;
                    case 10:
                        Console.Clear();
                        Console.WriteLine(_rentalService.GenerateSummary());
                        Console.ReadKey();
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

    private void PrintAvaiableEquipment()
    {
        Console.Clear();
        List<Equipment> availableEquipment = _rentalService.GetAvailableEquipment();
        for (int i = 0; i < availableEquipment.Count; i++)
        {
            Console.WriteLine(availableEquipment[i]);
        }
        Console.ReadKey();
    }

    private void PrintRenting()
    {
        Console.Clear();
        Console.WriteLine("Który użytkownik wybożycza?");
        for (int i = 0; i < _rentalService.UserList.Count; i++)
        {
            Console.WriteLine(i+". "+_rentalService.UserList[i]);
        }

        int userInput;
        userInput = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Co wyporzyczamy");
        for (int i = 0; i < _rentalService.EquipmentList.Count; i++)
        {
            Console.WriteLine(i+". "+_rentalService.EquipmentList[i]);
        }
        int equipmentInput;
        equipmentInput = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Do kiedy wypożycza (użyj formatu RRRR-MM-DD)?");
        DateOnly dateInput;
        dateInput = DateOnly.Parse(Console.ReadLine());
        if (_rentalService.Rent(_rentalService.UserList[userInput], _rentalService.EquipmentList[equipmentInput],
                dateInput))
        {
            Console.WriteLine("Poprawnie wypożyczono!");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Nie można dokonać wypożyczenia!");
            Console.ReadKey();
        }
    }

    private void PrintReturning()
    {
        Console.Clear();
        Console.WriteLine("Który użytkownik zwraca?");
        for (int i = 0; i < _rentalService.UserList.Count; i++)
        {
            Console.WriteLine(i+". "+_rentalService.UserList[i]);
        }
        
        int userInput;
        userInput = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Co zwraca");
        for (int i = 0; i < _rentalService.EquipmentList.Count; i++)
        {
            Console.WriteLine(i+". "+_rentalService.EquipmentList[i]);
        }
        int equipmentInput;
        equipmentInput = Int32.Parse(Console.ReadLine());

        int returnRentalIndex=0;

        for (int i = 0; i < _rentalService.RentalList.Count; i++)
        {
            if (_rentalService.RentalList[i].RentalUser == _rentalService.UserList[userInput]
                && _rentalService.RentalList[i].RentedEquipment == _rentalService.EquipmentList[equipmentInput]
                && _rentalService.RentalList[i].ActualReturnDate == null) 
            {
                returnRentalIndex = i;
                break;
            }
        }
        
        if (_rentalService.Return(_rentalService.UserList[userInput], _rentalService.EquipmentList[equipmentInput]))
        {
            _rentalService.RentalList[returnRentalIndex].ActualReturnDate=DateOnly.FromDateTime(DateTime.Now);
            Console.WriteLine("Poprawnie zwrócono!");
            Console.WriteLine($"Należne opłaty: {_rentalService.RentalList[returnRentalIndex].Fees}");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Nie można dokonać takiego zwrotu!");
            Console.ReadKey();
        }
    }

    private void PrintChangeStatus()
    {
        Console.Clear();
        Console.WriteLine("Czego chcesz zmienić status");
        for (int i = 0; i < _rentalService.EquipmentList.Count; i++)
        {
            Console.WriteLine(i+". "+_rentalService.EquipmentList[i]);
        }
        int equipmentInput;
        equipmentInput = Int32.Parse(Console.ReadLine());
        _rentalService.SwitchEquipmentStatus(_rentalService.EquipmentList[equipmentInput]);
        Console.WriteLine($"Zmieniono! {_rentalService.EquipmentList[equipmentInput]}");
        Console.ReadKey();
    }

    private void PrintUserRentals()
    {
        Console.Clear();
        Console.WriteLine("Który użytkownik chcesz sprawdzić?");
        for (int i = 0; i < _rentalService.UserList.Count; i++)
        {
            Console.WriteLine(i+". "+_rentalService.UserList[i]);
        }

        int userInput;
        userInput = Int32.Parse(Console.ReadLine());
        List<Rental> userRentals = _rentalService.GetActiveUserRentals(_rentalService.UserList[userInput]);
        for (int i = 0; i < userRentals.Count; i++)
        {
            Console.WriteLine($"{i+1}. Wypożyczono: {userRentals[i].RentedEquipment}, Data oddania:{userRentals[i].SetReturnDate}");
        }
        Console.ReadKey();
    }
    
    private void PrintOverduerRentals()
    {
        Console.Clear();
        
        List<Rental> overdueRentals = _rentalService.GetOverdueRentals();
        for (int i = 0; i < overdueRentals.Count; i++)
        {
            Console.WriteLine($"{i+1}. Wypożyczono: {overdueRentals[i].RentedEquipment}, Użytkownik:{overdueRentals[i].RentalUser}, Data oddania:{overdueRentals[i].SetReturnDate}");
        }
        Console.ReadKey();
    }
}