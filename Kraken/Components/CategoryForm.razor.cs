using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Extensions;
using DataCat = Kraken.Components.Models.Category;

namespace Kraken.Components;

public partial class CategoryForm : ComponentBase
{
    [Parameter] public DataCat? Category { get; set; }
    bool _success;
    MudForm _form;
    [Parameter] public EventCallback<bool> OnClose { get; set; }
    [Parameter] public EventCallback<string> OnValidate { get; set; }

    private async Task ValidateForm()
    {
        if(!_success) return;
        await OnValidate.InvokeAsync(_form.FieldId[0].As<string>() ?? string.Empty);
        await CloseForm();
    }
    
    private async Task CloseForm()
    {
        await OnClose.InvokeAsync(true);
    }
}