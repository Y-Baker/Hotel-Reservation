using System;
using Hotel_Reservation.Components.Elements;
using Hotel_Reservation.Data.Interface;
using Hotel_Reservation.Models;

namespace Hotel_Reservation.Data.Class;

public class UnitOfWork : IUnitOfWork
{
    private readonly HotelContext db;

    public UnitOfWork(HotelContext db)
    {
        this.db = db;
    }

    IGuestRepository? guestRepository;
    public IGuestRepository GuestRepository
    {
        get
        {
            if (guestRepository == null)
            {
                guestRepository = new GuestRepository(db);
            }
            return guestRepository;
        }
    }

    IGenericRepository<Room>? roomRepository;
    public IGenericRepository<Room> RoomRepository 
    {
        get
        {
            if (roomRepository == null)
            {
                roomRepository = new GenericRepository<Room>(db);
            }
            return roomRepository;
        }
    }

    IGenericRepository<Booking>? bookingRepository;
    public IGenericRepository<Booking> BookingRepository
    {
        get
        {
            if (bookingRepository == null)
            {
                bookingRepository = new GenericRepository<Booking>(db);
            }
            return bookingRepository;
        }
    }

    IGenericRepository<RoomType>? roomTypeRepository;
    public IGenericRepository<RoomType> RoomTypeRepository
    {
        get
        {
            if (roomTypeRepository == null)
            {
                roomTypeRepository = new GenericRepository<RoomType>(db);
            }
            return roomTypeRepository;
        }
    }

    IAmenityRepository? amenityRepository;
    public IAmenityRepository AmenityRepository
    {
        get
        {
            if (amenityRepository == null)
            {
                amenityRepository = new AmenityRepository(db);
            }
            return amenityRepository;
        }
    }

    IGenericRepository<RoomAmenity>? roomAmenityRepository;
    public IGenericRepository<RoomAmenity> RoomAmenityRepository
    {
        get
        {
            if (roomAmenityRepository == null)
            {
                roomAmenityRepository = new GenericRepository<RoomAmenity>(db);
            }
            return roomAmenityRepository;
        }
    }

    IGenericRepository<Service>? serviceRepository;
    public IGenericRepository<Service> ServiceRepository
    {
        get
        {
            if (serviceRepository == null)
            {
                serviceRepository = new GenericRepository<Service>(db);
            }
            return serviceRepository;
        }
    }

    public async Task Save()
    {
        await db.SaveChangesAsync();
    }

    public async Task ShowModal(Modal modal)
    {
        await modal.ShowModal();
    }
}
