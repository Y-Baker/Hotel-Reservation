using System;
using Hotel_Reservation.Components.Elements;
using Hotel_Reservation.Models;

namespace Hotel_Reservation.Data.Interface;

public interface IUnitOfWork
{
    public Task Save();
    public Task ShowModal(Modal modal);

    public IGuestRepository GuestRepository { get; }
    public IGenericRepository<Room> RoomRepository { get; }
    public IGenericRepository<Booking> BookingRepository { get; }
    public IGenericRepository<RoomType> RoomTypeRepository { get; }
    public IAmenityRepository AmenityRepository { get; }
    public IGenericRepository<RoomAmenity> RoomAmenityRepository { get; }
    public IGenericRepository<Service> ServiceRepository { get; }
}
