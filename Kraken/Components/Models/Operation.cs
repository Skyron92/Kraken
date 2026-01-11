namespace Kraken.Components.Models;

public class Operation
{
    private string _name = "Indéfini";
    public string Name => _name;
    public readonly Guid Id;
    private float _amount;
    public float Amount => _amount;
    private DateTime _date;
    public DateTime Date=> _date;

    public Operation(float amount)
    {
        _date = DateTime.Now;
        Id = Guid.NewGuid();
        _name= string.Empty;
        _amount = amount;
    }

    public void Modify(string name, float amount, DateTime date) {
        _name = name;
        _amount = amount;
        _date = date;
    }
}