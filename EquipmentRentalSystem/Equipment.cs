namespace EquipmentRentalSystem;

public abstract class Equipment
{
    private static int IdCounter { get; set; } = 1;
    public int Id { get; }
    public string Name { get; }
    public string Department { get; }
    public bool IsAvailable { get; set; }

    protected Equipment(string name, string department, bool isAvailable)
    {
        Id = IdCounter++;
        Name = name;
        Department = department;
        IsAvailable = isAvailable;
    }
}