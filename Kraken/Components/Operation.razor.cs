using Microsoft.AspNetCore.Components;
using DataOp = Kraken.Components.Models.Operation;

namespace Kraken.Components;

public partial class Operation : ComponentBase
{
    [Parameter] public required DataOp Data { get; set; }
    private string Name => Data.Name;
    private float Amount => Data.Amount;
    private DateTime Date => Data.Date;

    public void Modify() {
        Data.Modify(Name, Amount, Date);
    }
}