using Microsoft.AspNetCore.Components;

namespace Kraken.Components;

public partial class Operation : ComponentBase
{
    [Parameter] public required Operation Data { get; set; }
    private string _name;
    public float Amount;
    private DateTime _date;

    public Operation()
    {
        _date = DateTime.Now;
    }

    public void Modify(Operation newValues) {
        Data = newValues;
    }
}