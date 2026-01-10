using Microsoft.AspNetCore.Components;

namespace Kraken.Components;

public partial class Category : ComponentBase
{
    private string _name="This is my category";
    private float RemainingAmount { get; set; } = 50.266f;
    private List<Operation> _operations = new ();
    [Parameter] public EventCallback<Category> OnEdit { get; set; }
    
    private async Task Edit()
    {
        await OnEdit.InvokeAsync(this);
    }

    private void AddOperation(Operation operation) {
        float newAmount = RemainingAmount - operation.Amount;
        RemainingAmount = newAmount;
        _operations.Add(operation);
    }
    
    private void ModifyOperation(Operation operation, Operation newOperation) {
        _operations.Find(o => o == operation)?.Modify(newOperation);
    }

    private void RemoveOperation(Operation operation) {
        _operations.Remove(operation);
    }
}