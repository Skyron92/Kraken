using Microsoft.AspNetCore.Components;

namespace Kraken.Components;

public partial class CategoryButton : ComponentBase
{
    [Parameter] public bool IsOpen { get; set; }
    [Parameter] public EventCallback<bool> IsOpenChanged { get; set; }
    
    async Task DisplayForm()
    {
        IsOpen = !IsOpen;
        await IsOpenChanged.InvokeAsync(IsOpen);
    }
}