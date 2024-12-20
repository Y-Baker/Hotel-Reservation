using Hotel_Reservation.Data.Interface;
using Hotel_Reservation.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Data.Class;

public class GuestRepository : GenericRepository<Guest>, IGuestRepository
{
    public GuestRepository(HotelContext _db) : base(_db) { }

    public async Task<bool> IsEmailExists(string email)
    {
        return await dbset.AnyAsync(e => e.Email == email);
    }

    public async Task<bool> IsExists(Guest guest)
    {
        return await dbset.AnyAsync(e => e.Ssn == guest.Ssn);
    }

    public async Task<bool> IsExists(string ssn)
    {
        return await dbset.AnyAsync(e => e.Ssn == ssn);
    }
}
