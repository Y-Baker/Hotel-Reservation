using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Hotel_Reservation.Components.Elements;
using Hotel_Reservation.Data.Interface;
using Hotel_Reservation.Models;
using Hotel_Reservation.Models.Validation;
using Microsoft.AspNetCore.Components;

namespace Hotel_Reservation.Components.Pages;

public partial class Bookings
{
    Booking? _booking = new();
    List<Booking>? bookings = new List<Booking>();
    List<Room>? rooms = new List<Room>();
    List<Guest> guests = new List<Guest>();

    int RoomId
    {
        get => _booking?.RoomId ?? 0;
        set
        {
            if (_booking is null)
                return;
            _booking.RoomId = value;
            CalculateTotalAmount();
        }
    }

    DateOnly CheckIn
    {
        get => _booking?.CheckIn ?? DateOnly.FromDateTime(DateTime.UtcNow);
        set
        {
            if (_booking is null)
                return;
            _booking.CheckIn = value;
            CalculateTotalAmount();
        }
    }

    DateOnly CheckOut
    {
        get => _booking?.CheckOut ?? DateOnly.FromDateTime(DateTime.UtcNow);
        set
        {
            if (_booking is null)
                return;
            _booking.CheckOut = value;
            CalculateTotalAmount();
        }
    }

    bool isLoading = false;
    Booking? _ToDelete;
    Modal? modal;

    [Inject]
    public IUnitOfWork? _unit { get; set; }

    protected async override Task OnInitializedAsync()
    {
        ArgumentNullException.ThrowIfNull(_unit);
        bookings = await _unit.BookingRepository.GetAll() as List<Booking>;
        rooms = await _unit.RoomRepository.GetAll() as List<Room>;
        guests = await _unit.GuestRepository.GetAll() as List<Guest> ?? new();

        await base.OnInitializedAsync();
    }

    private void CalculateTotalAmount()
    {
        if (_booking is null)
            return;

        var validator = new BookingValidator();
        var result = validator.Validate(_booking);
        if (!result.IsValid)
            return;

        if (_booking.CheckIn is null || _booking.CheckOut is null)
            return;

        int days = (_booking.CheckOut.Value.ToDateTime(TimeOnly.MinValue) - _booking.CheckIn.Value.ToDateTime(TimeOnly.MinValue)).Days;

        if (_booking.CheckIn < _booking.CheckOut)
        {
            var room = rooms?.FirstOrDefault(r => r.RoomId == _booking.RoomId);
            if (room is not null)
            {
                _booking.TotalAmount = days * room.PricePerNight;
            }
            else
            {
                _booking.TotalAmount = 0;
            }
        }
        else
        {
            _booking.TotalAmount = 0;
        }

        StateHasChanged();
    }


    private async Task HandleValidSubmit()
    {
        if (isLoading)
        {
            Console.WriteLine("Can't Do New Process While Loading");
            return;
        }
        if (_booking is null)
        {
            Console.WriteLine($"{nameof(_booking)} Not Found");
            return;
        }

        var validator = new BookingValidator();
        var result = validator.Validate(_booking);
        if (!result.IsValid)
            return;

        isLoading = true;
        StateHasChanged();

        try
        {
            CalculateTotalAmount();
            string bookSerialized = _booking is null ? string.Empty : JsonSerializer.Serialize(_booking);
            Booking? validBooking = JsonSerializer.Deserialize<Booking>(bookSerialized);
            ArgumentNullException.ThrowIfNull(validBooking, nameof(validBooking));

            Booking? MemGuest = bookings?.FirstOrDefault(e => e.BookingId == validBooking.BookingId);

            ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
            if (MemGuest is null)
            {
                await _unit.BookingRepository.Add(validBooking);
            }
            else
            {
                await _unit.BookingRepository.Update(validBooking);
            }
            await _unit.Save();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine($"{nameof(_booking)} Not Saved");
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
            bookings = await _unit.BookingRepository.GetAll() as List<Booking>;
            isLoading = false;
            Clear();
            StateHasChanged();
        }
    }

    private void Edit(Booking toBeEditedBooking)
    {
        string? bookSerialized = JsonSerializer.Serialize(toBeEditedBooking);
        if (bookSerialized is not null)
            _booking = JsonSerializer.Deserialize<Booking>(bookSerialized);

        StateHasChanged();
    }

    private async void PrepareForDelete(Booking booking)
    {
        ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
        ArgumentNullException.ThrowIfNull(modal, nameof(modal));
        _ToDelete = booking;
        await _unit.ShowModal(modal);
    }
    private async Task ConfirmDelete()
    {
        if (_ToDelete != null)
        {
            await DeleteRoom(_ToDelete);
        }
    }
    private async Task DeleteRoom(Booking booking)
    {
        isLoading = true;
        ArgumentNullException.ThrowIfNull(booking, nameof(booking));
        ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));

        try
        {
            bookings?.Remove(booking);
            await _unit.BookingRepository.Delete(booking);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine("Booking Not Saved");
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
            bookings = await _unit.BookingRepository.GetAll() as List<Booking>;
            isLoading = false;
            StateHasChanged();
        }
    }

    private void Clear()
    {
        _booking = new();
    }
}