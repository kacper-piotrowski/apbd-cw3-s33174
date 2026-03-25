namespace EquipmentRentalSystem;

class Program
{
    static void Main(string[] args)
    {
        RentalService Rs = new RentalService();
        ConsoleMenu Menu = new ConsoleMenu(Rs);
        Menu.Run();
    }
}