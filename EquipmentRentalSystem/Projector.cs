namespace EquipmentRentalSystem;

public class Projector : Equipment
{
    public string Resolution { get; }
    public string Brightness { get; }
    
    public Projector(string name, string department, bool isAvailable,  string resolution, string brightness) : base(name, department, isAvailable)
        {
        Resolution = resolution;
        Brightness = brightness;
        }
    
    public override string ToString()
    {
        return ($"Projektor: {Name}, wydział: {Department}, jest dostępny:{IsAvailable}, rozdzielczość: {Resolution}, jasność:{Brightness}");
    }
}