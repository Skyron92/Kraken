using Microsoft.AspNetCore.Components;

namespace Kraken.Components;

public partial class CategoryForm : ComponentBase
{
    [Parameter] public Category? Category { get; set; }
}