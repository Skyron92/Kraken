using Microsoft.AspNetCore.Components;
using DataOp = Kraken.Components.Models.Operation;
using DataCat = Kraken.Components.Models.Category;
using UIOp = Kraken.Components.Operation;

namespace Kraken.Components;

public partial class Category : ComponentBase
{
    [Parameter] public required DataCat CategoryData { get; set; }
    private string Name => CategoryData.Name;
    private float RemainingAmount {
        get => CategoryData.RemainingAmount;
        set => CategoryData.RemainingAmount = value;
    }
    private List<DataOp> Operations => CategoryData.Operations;
    [Parameter] public EventCallback<Guid> OnEdit { get; set; }
    
    private async Task Edit()
    {
        await OnEdit.InvokeAsync(CategoryData.Id);
    }
}