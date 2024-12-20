using Hotel_Reservation.Models;

namespace Hotel_Reservation.Data.Interface;

public interface IGuestRepository : IGenericRepository<Guest>
{
    public Task<bool> IsEmailExists(string email);
    public Task<bool> IsExists(Guest guest);
    public Task<bool> IsExists(string ssn);
}
