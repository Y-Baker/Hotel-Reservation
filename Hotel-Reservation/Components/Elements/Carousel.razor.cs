using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Hotel_Reservation.Components.Elements;
public partial class Carousel
{
    const string carouselFunctionName = "startCarousel";

    [Inject]
    private IJSRuntime? _jsRuntime { get; set; }

    string carouselName = Guid.NewGuid().ToString();

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            ArgumentNullException.ThrowIfNull(_jsRuntime);
            object[] parms = { carouselName };
            await _jsRuntime.InvokeVoidAsync(carouselFunctionName, parms);
        }
    }
}
