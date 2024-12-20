using System;
using Hotel_Reservation.Models;

namespace Hotel_Reservation.Data.Interface;

public interface IAmenityRepository : IGenericRepository<Amenity>
{
    public Task<List<Amenity>> GetByRoomId(int roomId);
}
