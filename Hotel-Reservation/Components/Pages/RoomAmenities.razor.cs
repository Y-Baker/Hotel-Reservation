using System.Text.Json;
using Hotel_Reservation.Components.Elements;
using Hotel_Reservation.Data.Interface;
using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Components;

namespace Hotel_Reservation.Components.Pages;

public partial class RoomAmenities
{
    RoomAmenity? _roomAmenity = new();
    List<RoomAmenity>? roomAmenities = new List<RoomAmenity>();
    List<Room>? rooms = new List<Room>();
    List<Amenity>? amenities = new List<Amenity>();

    bool isLoading = false;
    RoomAmenity? _roomAmenityToDelete;
    Modal? modal;

    [Inject]
    public IUnitOfWork? _unit { get; set; }

    protected async override Task OnInitializedAsync()
    {
        ArgumentNullException.ThrowIfNull(_unit);
        roomAmenities = await _unit.RoomAmenityRepository.GetAll() as List<RoomAmenity>;
        rooms = await _unit.RoomRepository.GetAll() as List<Room>;
        amenities = await _unit.AmenityRepository.GetAll() as List<Amenity> ?? new();

        await base.OnInitializedAsync();
    }
    private async Task HandleValidSubmit()
    {
        if (isLoading)
        {
            Console.WriteLine("Can't Do New Process While Loading");
            return;
        }
        if (_roomAmenity is null || _roomAmenity.RoomId == 0 || _roomAmenity.AmenityId == 0)
            return;

        isLoading = true;
        StateHasChanged();

        try
        {
            string roomAmenitySerialized = _roomAmenity is null ? string.Empty : JsonSerializer.Serialize(_roomAmenity);
            RoomAmenity? validRoomAmenity = JsonSerializer.Deserialize<RoomAmenity>(roomAmenitySerialized);
            ArgumentNullException.ThrowIfNull(validRoomAmenity, nameof(validRoomAmenity));

            RoomAmenity? MemGuest = roomAmenities?.FirstOrDefault(e => e.RoomId == validRoomAmenity.RoomId && e.AmenityId == validRoomAmenity.AmenityId);

            ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
            if (MemGuest is null)
            {
                await _unit.RoomAmenityRepository.Add(validRoomAmenity);
            }
            else
            {
                await _unit.RoomAmenityRepository.Update(validRoomAmenity);
            }
            await _unit.Save();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
            roomAmenities = await _unit.RoomAmenityRepository.GetAll() as List<RoomAmenity>;
            isLoading = false;
            Clear();
            StateHasChanged();
        }
    }

    private void EditRoomAmenity(RoomAmenity roomAmenity)
    {
        string? roomAmentitySerialized = JsonSerializer.Serialize(roomAmenity);
        if (roomAmentitySerialized is not null)
            _roomAmenity = JsonSerializer.Deserialize<RoomAmenity>(roomAmentitySerialized);

        StateHasChanged();
    }

    private async void PrepareForDelete(RoomAmenity roomAmenity)
    {
        ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
        ArgumentNullException.ThrowIfNull(modal, nameof(modal));
        _roomAmenityToDelete = roomAmenity;
        await _unit.ShowModal(modal);
    }
    private async Task ConfirmDelete()
    {
        if (_roomAmenityToDelete != null)
        {
            await DeleteRoomAmenity(_roomAmenityToDelete);
        }
    }
    private async Task DeleteRoomAmenity(RoomAmenity roomAmenity)
    {
        isLoading = true;
        ArgumentNullException.ThrowIfNull(roomAmenity, nameof(roomAmenity));
        ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));

        try
        {
            roomAmenities?.Remove(roomAmenity);
            await _unit.RoomAmenityRepository.Delete(roomAmenity);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine("RoomAmenity Not Saved");
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
            roomAmenities = await _unit.RoomAmenityRepository.GetAll() as List<RoomAmenity>;
            isLoading = false;
            StateHasChanged();
        }
    }

    private void Clear()
    {
        _roomAmenity = new RoomAmenity();
    }
}
