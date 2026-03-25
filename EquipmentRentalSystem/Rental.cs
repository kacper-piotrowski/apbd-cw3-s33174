namespace EquipmentRentalSystem;

public class Rental
{
    public DateOnly RentalDate { get; }
    public DateOnly SetReturnDate { get; }
    public DateOnly? ActualReturnDate { get; set; }
    public User RentalUser { get; }
    public Equipment RentedEquipment { get; }
    public double Fees { get; set; }
    
    public Rental(DateOnly rentalDate,  DateOnly setReturnDate, User user, Equipment rentalEquipment)
    {
        RentalDate = rentalDate;
        SetReturnDate = setReturnDate;
        RentalUser = user;
        RentedEquipment = rentalEquipment;
    }
}