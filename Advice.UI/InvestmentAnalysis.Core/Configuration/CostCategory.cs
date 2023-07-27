namespace InvestmentAnalysis.Core.Configuration;
public record CostCategory
{
    public List<CategorySubElement> CategoryItemList { get; }
    public CategorySubElement RootCategory
    {
        get
        {
            return CategoryItemList.FirstOrDefault();
        }
    }
    public CostCategory(string categoryName)
    {
        var sourceItems = categoryName.Split('.');
        int level = 0;
        CategoryItemList = new List<CategorySubElement>();
        foreach (var item in sourceItems)
        {
            CategoryItemList.Add(new CategorySubElement { Level = level, ElementName = item });
            level++;
        }
        Value = categoryName;
    }
    public string Value { get; }
    public static implicit operator string(CostCategory costCategory)
    {
        return costCategory.Value;
    }

    public static implicit operator CostCategory(string costCategoryName)
    {
        return new CostCategory(costCategoryName);
    }
}
