using DataOp = Kraken.Components.Models.Operation;

namespace Kraken.Components.Models;

public class Category
{
    public string Name { get; set; } = "Name";
    public readonly Guid Id;
    public float RemainingAmount { get; set; } = 50.26f;
    public readonly List<DataOp> Operations = new();

    public Category(Guid id)
    {
        Id = id;
    }

    public async Task GetOperations()
    {
        // API Call
        Operations.Clear();
        RemainingAmount = 0;
        for (int i = 0; i < 2; i++)
        { 
            var op = CreateFakeOperation();
            Operations.Add(op);
            RemainingAmount += op.Amount;
        }
    }

    private DataOp CreateFakeOperation()
    {
        Random rand = new Random();
        float amount = rand.Next(-100, 100);
        float decimals = rand.Next(0, 99);
        amount += decimals * 0.01f;
        return new DataOp(amount);
    }

    public void Modify(string name)
    {
        Name = name;
    }
}