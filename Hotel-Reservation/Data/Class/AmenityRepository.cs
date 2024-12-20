using System;
using Hotel_Reservation.Data.Interface;
using Hotel_Reservation.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Data.Class;

public class AmenityRepository : GenericRepository<Amenity>, IAmenityRepository
{
    public AmenityRepository(HotelContext _db) : base(_db) {}

    public Task<List<Amenity>> GetByRoomId(int roomId)
    {
        return db.RoomAmenities
            .Where(e => e.RoomId == roomId)
            .Select(e => e.Amenity)
            .ToListAsync();
    }
}
