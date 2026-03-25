namespace EquipmentRentalSystem;

public class Camera : Equipment
{
    public string Lens { get; }
    public int Batteries { get; }

    public Camera(string name, string department, bool isAvailable, string lens, int batteries) : base(name, department, isAvailable)
    {
        Lens = lens;
        Batteries = batteries;
    }
    
    public override string ToString()
    {
        return ($"Aparat: {Name}, wydział: {Department}, jest dostępny:{IsAvailable}, obiektyw: {Lens}, liczba baterii:{Batteries}");
    }
}