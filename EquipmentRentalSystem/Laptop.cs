namespace EquipmentRentalSystem;

public class Laptop : Equipment
{
    public string Processor { get; }
    public string GraphicsCard { get; }

    public Laptop(string name, string department, bool isAvailable, string processor, string graphicsCard) : base(name, department, isAvailable)
    {
        Processor = processor;
        GraphicsCard = graphicsCard;
    }
}