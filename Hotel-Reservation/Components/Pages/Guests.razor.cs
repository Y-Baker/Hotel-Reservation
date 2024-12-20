using Hotel_Reservation.Components.Elements;
using Hotel_Reservation.Data.Interface;
using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace Hotel_Reservation.Components.Pages;

public partial class Guests
{
    Guest? _guest = new();
    List<Guest>? guests = new List<Guest>();
    bool isLoading = false;
    Guest? _guestToDelete;
    Modal? modal;

    [Inject]
    public IUnitOfWork? _unit { get; set; }

    protected async override Task OnInitializedAsync()
    {
        ArgumentNullException.ThrowIfNull(_unit);
        guests = await _unit.GuestRepository.GetAll() as List<Guest>;

        await base.OnInitializedAsync();
    }
    private async Task HandleValidSubmit()
    {
        if (isLoading)
        {
            Console.WriteLine("Can't Do New Process While Loading");
            return;
        }
        if (_guest is null)
        {
            Console.WriteLine($"{nameof(_guest)} Not Found");
            return;
        }
        if (string.IsNullOrEmpty(_guest.Ssn))
            return;

        isLoading = true;
        StateHasChanged();

        try
        {
            string guestSerialized = _guest is null ? string.Empty : JsonSerializer.Serialize(_guest);
            Guest? validGuest = JsonSerializer.Deserialize<Guest>(guestSerialized);
            ArgumentNullException.ThrowIfNull(validGuest, nameof(validGuest));

            Guest? MemGuest = guests?.FirstOrDefault(e => e.Ssn == validGuest.Ssn);

            ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
            if (MemGuest is null)
            {
                await _unit.GuestRepository.Add(validGuest);
            }
            else
            {
                await _unit.GuestRepository.Update(validGuest);
            }
            await _unit.Save();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine($"{nameof(_guest)} Not Saved");
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
            guests = await _unit.GuestRepository.GetAll() as List<Guest>;
            isLoading = false;
            Clear();
            StateHasChanged();
        }
    }

    private void EditGuest(Guest toBeEditedGuest)
    {
        string? guestSerialized = JsonSerializer.Serialize(toBeEditedGuest);
        if (guestSerialized is not null)
            _guest = JsonSerializer.Deserialize<Guest>(guestSerialized);

        StateHasChanged();
    }

    private async void PrepareForDelete(Guest guest)
    {
        ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
        ArgumentNullException.ThrowIfNull(modal, nameof(modal));
        _guestToDelete = guest;
        await _unit.ShowModal(modal);
    }
    private async Task ConfirmDelete()
    {
        if (_guestToDelete != null)
        {
            await DeleteGuest(_guestToDelete);
        }
    }
    private async Task DeleteGuest(Guest guest)
    {
        isLoading = true;
        ArgumentNullException.ThrowIfNull(guest, nameof(guest));
        ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));

        try
        {
            guests?.Remove(guest);
            await _unit.GuestRepository.Delete(guest);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine("Guest Not Saved");
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
            guests = await _unit.GuestRepository.GetAll() as List<Guest>;
            isLoading = false;
            StateHasChanged();
        }
    }

    private void Clear()
    {
        _guest = new();
    }
}