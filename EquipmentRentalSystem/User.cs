namespace EquipmentRentalSystem;

public class User
{
    private static int IdCounter { get; set; } = 1;
    public int Id { get; }
    public string Name { get; }
    public string Surname { get; }
    public UserType Type { get; }

    public User(string name, string surname, UserType type)
    {
        Id = IdCounter++;
        Name = name;
        Surname = surname;
        Type = type;
    }

}