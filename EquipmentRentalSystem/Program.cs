namespace EquipmentRentalSystem;

class Program
{
    static void Main(string[] args)
    {
        RentalService Rs = new RentalService();
        Console.WriteLine("Czy chcesz uruchomić scenariusz demo przed startem? (y/n)");
        if (Console.ReadLine()?.ToLower() == "y")
        {
            DemoMode(Rs);
            Console.Clear();
        }
        ConsoleMenu Menu = new ConsoleMenu(Rs);
        Menu.Run();
    }
    
    public static void DemoMode(RentalService rs)
{
    Console.WriteLine("Scenariusz demo:");
    
    Equipment laptop = new Laptop("MacBook Pro", "Informatyka", true, "M2", "Integrated");
    Equipment camera = new Camera("Sony A7IV", "Zarządzanie informacją", true, "24-70mm", 3);
    Equipment projector = new Projector("BenQ projector", "Japonistyka", true, "4K", "3000lm");
    rs.AddEquipment(laptop);
    Console.WriteLine($"Dodano: {laptop}");
    rs.AddEquipment(camera);
    Console.WriteLine($"Dodano: {camera}");
    rs.AddEquipment(projector);
    Console.WriteLine($"Dodano: {projector}");
    
    User student = new User("Adam", "Nowak", UserType.Student);
    User employee = new User("Anna", "Wójcik", UserType.Employee);
    rs.AddUser(student);
    Console.WriteLine($"Dodano użytkownika: {student}");
    rs.AddUser(employee);
    Console.WriteLine($"Dodano użytkownika: {employee}");
    
    DateOnly sevenDaysLater = DateOnly.FromDateTime(DateTime.Now.AddDays(7));
    bool successRent = rs.Rent(student, laptop, sevenDaysLater);
    Console.WriteLine($"Wypożyczenie laptopa studentowi: {successRent}");
    
    bool failRent1 = rs.Rent(employee, laptop, sevenDaysLater);
    Console.WriteLine($"Wypożyczenie tego samego laptopa: {failRent1}");
    
    rs.Rent(student, camera, sevenDaysLater);
    bool failRent2 = rs.Rent(student, projector, sevenDaysLater);
    Console.WriteLine($"Próba wypożyczenia 3. rzeczy przez studenta: {failRent2}");
    
    bool returnOnTime = rs.Return(student, laptop);
    Console.WriteLine($"Zwrot laptopa w terminie: {returnOnTime}");


    DateOnly yesterday = DateOnly.FromDateTime(DateTime.Now.AddDays(-1));
    DateOnly tenDaysAgo = DateOnly.FromDateTime(DateTime.Now.AddDays(-10));
    
    Rental lateRental = new Rental(tenDaysAgo, yesterday, employee, projector);
    rs.RentalList.Add(lateRental);
    projector.IsAvailable = false;

    Console.WriteLine("Anna oddaje projektor dzień po terminie");
    rs.Return(employee, projector);
    
    Rental finishedRental = rs.RentalList.Last();
    Console.WriteLine($"Zwrot spóźniony, kara = {finishedRental.Fees} zł.");
    
    Console.WriteLine("Raport końcowy: ");
    Console.WriteLine(rs.GenerateSummary());
    
    Console.WriteLine("\nKoniec scenariusza demo kliknij by kontynuować...");
    Console.ReadKey();
}
}