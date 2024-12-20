using System.Text.Json;
using Hotel_Reservation.Components.Elements;
using Hotel_Reservation.Data.Interface;
using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Components;

namespace Hotel_Reservation.Components.Pages;

public partial class Services
{
    Service? _service = new();
    List<Service>? services = new List<Service>();

    bool isLoading = false;
    Service? _serviceToDelete;
    Modal? modal;
    
    [Inject]
    public IUnitOfWork? _unit { get; set; }

    protected async override Task OnInitializedAsync()
    {
        ArgumentNullException.ThrowIfNull(_unit);
        services = await _unit.ServiceRepository.GetAll() as List<Service>;

        await base.OnInitializedAsync();
    }

    private async Task HandleValidSubmit()
    {
        if (isLoading)
        {
            Console.WriteLine("Can't Do New Process While Loading");
            return;
        }
        if (_service is null || string.IsNullOrEmpty(_service.Name))
            return;
        

        isLoading = true;
        StateHasChanged();

        try
        {
            string serviceSerialized = _service is null ? string.Empty : JsonSerializer.Serialize(_service);
            Service? validService = JsonSerializer.Deserialize<Service>(serviceSerialized);
            ArgumentNullException.ThrowIfNull(validService, nameof(validService));

            Service? MemService = services?.FirstOrDefault(e => e.ServiceId == validService.ServiceId);

            ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
            if (MemService is null)
            {
                await _unit.ServiceRepository.Add(validService);
            }
            else
            {
                await _unit.ServiceRepository.Update(validService);
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
            services = await _unit.ServiceRepository.GetAll() as List<Service>;
            isLoading = false;
            Clear();
            StateHasChanged();
        }
    }

    private void EditService(Service service)
    {
       string serviceSerialized = service is null ? string.Empty : JsonSerializer.Serialize(service);
        _service = JsonSerializer.Deserialize<Service>(serviceSerialized);

        StateHasChanged();
    }

    private async void PrepareForDelete(Service service)
    {
        ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
        ArgumentNullException.ThrowIfNull(modal, nameof(modal));
        _serviceToDelete = service;
        await _unit.ShowModal(modal);
    }

    private async Task ConfirmDelete()
    {
        if (_serviceToDelete != null)
        {
            await Delete(_serviceToDelete);
        }
    }

    private async Task Delete(Service service)
    {
        isLoading = true;
        ArgumentNullException.ThrowIfNull(service, nameof(service));
        ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));

        try
        {
            services?.Remove(service);
            await _unit.ServiceRepository.Delete(service);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_unit, nameof(_unit));
            services = await _unit.ServiceRepository.GetAll() as List<Service>;
            isLoading = false;
            StateHasChanged();
        }
    }

    private void Clear()
    {
        _service = new Service();
    }
}
