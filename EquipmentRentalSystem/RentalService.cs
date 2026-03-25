using System.Text;

namespace EquipmentRentalSystem;

public class RentalService
{
    public List<User> UserList { get; } = new();
    public List<Equipment> EquipmentList { get; } = new();
    public List<Rental> RentalList { get; } = new();

    public bool CanRent(User user, Equipment equipment)
    {
        int ActiveRentals = 0;
        for (int i = 0; i < RentalList.Count; i++)
        {
            if (RentalList[i].RentalUser == user && RentalList[i].ActualReturnDate == null)
            {
                ActiveRentals++;
            }
        }
        if (user.Type == UserType.Student)
        {
            if (!equipment.IsAvailable || ActiveRentals >= 2)
            {
                return false;
            }
        }

        if (user.Type == UserType.Employee)
        {
            if (!equipment.IsAvailable || ActiveRentals >= 5)
            {
                return false;
            }
        }

        return true;
    }

    public bool Rent(User user, Equipment equipment, DateOnly returnDate)
    {
        if (CanRent(user, equipment)){
            DateOnly rentalDate = DateOnly.FromDateTime(DateTime.Now);
            Rental CurrentRental = new Rental(rentalDate, returnDate, user, equipment);
            RentalList.Add(CurrentRental);
            equipment.IsAvailable = false;
            return true;
        }
        return false;
    }

    public bool Return(User user, Equipment equipment)
    {
        DateOnly returnDate = DateOnly.FromDateTime(DateTime.Now);
        for (int i = 0; i < RentalList.Count(); i++)
        {
            if (RentalList[i].RentedEquipment == equipment && RentalList[i].RentalUser == user && RentalList[i].ActualReturnDate == null)
            {
                int lateDays = returnDate.DayNumber - RentalList[i].SetReturnDate.DayNumber;
                equipment.IsAvailable = true;
                RentalList[i].ActualReturnDate = returnDate;
                RentalList[i].Fees = lateDays>0 ? 5*lateDays : 0;
                return true;
            }
        }

        return false;
    }

    public void AddEquipment(Equipment equipment)
    {
        EquipmentList.Add(equipment);
    }

    public void AddUser(User user)
    {
        UserList.Add(user);
    }

    public List<Rental> GetActiveUserRentals(User user)
    {
        List<Rental> activeUserRentals = new();
        for (int i = 0; i < RentalList.Count(); i++)
        {
            if (RentalList[i].RentalUser == user && RentalList[i].ActualReturnDate == null)
            {
                activeUserRentals.Add(RentalList[i]);
            }
        }

        return activeUserRentals;
    }

    public List<Equipment> GetAvailableEquipment()
    {
        List<Equipment> availableEquipment = new();
        for (int i = 0; i < EquipmentList.Count(); i++)
        {
            if (EquipmentList[i].IsAvailable)
            {
                availableEquipment.Add(EquipmentList[i]);
            }
        }

        return availableEquipment;
    }

    public bool SwitchEquipmentStatus(Equipment equipment)
    {
        for (int i = 0; i < EquipmentList.Count(); i++)
        {
            if (EquipmentList[i] == equipment)
            {
                if(EquipmentList[i].IsAvailable)
                {
                    EquipmentList[i].IsAvailable = false;
                    return true;
                }
                else
                {
                    EquipmentList[i].IsAvailable = true;
                    return true;
                }
            }
        }

        return false;
    }

    public List<Rental> GetOverdueRentals()
    {
        List<Rental> overdueRentals = new();
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        for (int i = 0; i < RentalList.Count(); i++)
        {
            if (RentalList[i].SetReturnDate < today && RentalList[i].ActualReturnDate == null)
            {
                overdueRentals.Add(RentalList[i]);
            }
        }
        return overdueRentals;
    }

    public String GenerateSummary()
    {
        StringBuilder summary = new StringBuilder();
        summary.Append($"Liczba użytkowników w systemie: {UserList.Count};");
        summary.Append($"Liczba sprzętu w systemie: {EquipmentList.Count};");
        summary.Append($"Liczba wszystkich wyporzyczeń: {RentalList.Count};");
        summary.Append($"Liczba przeterminowanych wypożyczeń: {GetOverdueRentals().Count};");
        return summary.ToString();
    }
}