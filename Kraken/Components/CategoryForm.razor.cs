using Microsoft.AspNetCore.Components;
using DataCat = Kraken.Components.Models.Category;

namespace Kraken.Components;

public partial class CategoryForm : ComponentBase
{
    [Parameter]
    public DataCat? Category { get; set; }

    [Parameter]
    public bool IsOpen { get; set; }

    [Parameter]
    public EventCallback<bool> IsOpenChanged { get; set; }

    [Parameter]
    public EventCallback<string> OnValidate { get; set; }

    private bool Success { get; set; }
    private string Name { get; set; } = "";

    protected override void OnParametersSet()
    {
        Name = Category?.Name ?? "";
    }
    
    private async Task ValidateForm()
    {
        if (!Success || Name == "") return;
        await OnValidate.InvokeAsync(Name);
        await CloseForm();
    }

    private async Task CloseForm()
    {
        IsOpen = false;
        await IsOpenChanged.InvokeAsync(IsOpen);
    }
}