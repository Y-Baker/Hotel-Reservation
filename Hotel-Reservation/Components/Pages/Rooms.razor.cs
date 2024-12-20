using System.Text.Json;
using Hotel_Reservation.Components.Elements;
using Hotel_Reservation.Data.Interface;
using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Components;

namespace Hotel_Reservation.Components.Pages;
public partial class Rooms
{
    Room? _room = new();
    List<Room>? rooms = new List<Room>();
    List<RoomType>? roomTypes = new List<RoomType>();
    List<Amenity> amenities = new List<Amenity>();

    bool isLoading = false;
    Room? _roomToDelete;
    Modal? modal;

    [Inject]
    public IUnitOfWork? _unit { get; set; }

    protected async override Task OnInitializedAsync()
    {
        ArgumentNullException.ThrowIfNull(_unit);
        rooms = await _unit.RoomRepository.GetAll() as List<Room>;
        roomTypes = await _unit.RoomTypeRepository.GetAll() as List<RoomType>;
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
        if (_room is null)
        {
            Console.WriteLine($"{nameof(_room)} Not Found");
            return;
        }
        if (string.IsNullOrEmpty(_room.RoomNumber))
            return;

        isLoading = true;
        StateHasChanged();

        try
        {
            string roomSerialized = _room is null ? string.Empty : JsonSerializer.Serialize(_room);
            Room? validRoom = JsonSerializer.Deserialize<Room>(roomSerialized);
            ArgumentNullException.ThrowIfNull(validRoom, nameof(validRoom));

            Room? MemGuest = rooms?.FirstOrDefault(e => e.RoomId == validRoom.RoomId);

            ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
            if (MemGuest is null)
            {
                await _unit.RoomRepository.Add(validRoom);
            }
            else
            {
                await _unit.RoomRepository.Update(validRoom);
            }
            await _unit.Save();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine($"{nameof(_room)} Not Saved");
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
            rooms = await _unit.RoomRepository.GetAll() as List<Room>;
            isLoading = false;
            Clear();
            StateHasChanged();
        }
    }

    private void EditRoom(Room toBeEditedRoom)
    {
        string? roomSerialized = JsonSerializer.Serialize(toBeEditedRoom);
        if (roomSerialized is not null)
            _room = JsonSerializer.Deserialize<Room>(roomSerialized);

        StateHasChanged();
    }

    private async void PrepareForDelete(Room room)
    {
        ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
        ArgumentNullException.ThrowIfNull(modal, nameof(modal));
        _roomToDelete = room;
        await _unit.ShowModal(modal);
    }
    private async Task ConfirmDelete()
    {
        if (_roomToDelete != null)
        {
            await DeleteRoom(_roomToDelete);
        }
    }
    private async Task DeleteRoom(Room room)
    {
        isLoading = true;
        ArgumentNullException.ThrowIfNull(room, nameof(room));
        ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));

        try
        {
            rooms?.Remove(room);
            await _unit.RoomRepository.Delete(room);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine("Room Not Saved");
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
            rooms = await _unit.RoomRepository.GetAll() as List<Room>;
            isLoading = false;
            StateHasChanged();
        }
    }

    private void Clear()
    {
        _room = new();
    }
}