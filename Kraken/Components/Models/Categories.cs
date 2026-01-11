using DataCat = Kraken.Components.Models.Category;

namespace Kraken.Components.Models;

public class Categories
{
    public bool IsEditing;
    public DataCat? CategoryEditing;
    public readonly List<DataCat> Values = new();
    
    public async Task GetCategories()
    {
        // API call
        Values.Clear();
        for (int i = 0; i < 3; i++) {
            Values.Add(CreateFakeCategory(i));
        }
    }

    /// <summary>
    /// Fake function used to simulate an API call returning the result of a GET HTTP request
    /// </summary>
    private DataCat CreateFakeCategory(int i) {
        DataCat cat = new DataCat(Guid.NewGuid()) {
            Name = $"Category {i}"
        };
        return cat;
    }

    public void EditCategory(Guid id)
    {
        IsEditing = true;
        CategoryEditing = Values.Find(x => x.Id == id);
    }

    public void CancelEditing(bool cancel)
    {
        IsEditing = cancel;
        CategoryEditing = null;
    }

    public void Validate(string name)
    {
        if (!IsEditing) return;
        if (CategoryEditing == null) ValidateCreation(name);
        else ValidateEdition(name);
    }

    private void ValidateEdition(string name)
    {
        CategoryEditing?.Modify(name);
    }

    private void ValidateCreation(string name)
    {
        DataCat cat = new DataCat(Guid.NewGuid()) {
            Name = CategoryEditing!.Name
        };
        Values.Add(cat);
    }
}