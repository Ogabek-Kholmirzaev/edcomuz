namespace Expense.Blazor.Models.Reports;

public class ExpenseInformation
{
    public string Name { get; set; } = default!;
    public decimal TotalPrice { get; set; }
    public int TotalCount { get; set; }

    public List<ExpenseInformation> GetExpenses()
    {
        return new List<ExpenseInformation>
        {
            new ExpenseInformation { Name = "January", TotalCount = 10, TotalPrice = 1000 },
            new ExpenseInformation { Name = "February", TotalCount = 44, TotalPrice = 2311 },
            new ExpenseInformation { Name = "March", TotalCount = 5, TotalPrice = 999 },
            new ExpenseInformation { Name = "April", TotalCount = 34, TotalPrice = 823 },
            new ExpenseInformation { Name = "May", TotalCount = 22, TotalPrice = 132 },
            new ExpenseInformation { Name = "June", TotalCount = 7, TotalPrice = 3532 },
            new ExpenseInformation { Name = "July", TotalCount = 15, TotalPrice = 1300 },
            new ExpenseInformation { Name = "August", TotalCount = 39, TotalPrice = 6100 },
            new ExpenseInformation { Name = "September", TotalCount = 31, TotalPrice = 3900 },
            new ExpenseInformation { Name = "October", TotalCount = 25, TotalPrice = 4532 },
            new ExpenseInformation { Name = "November", TotalCount = 19, TotalPrice = 1234 },
            new ExpenseInformation { Name = "December", TotalCount = 9, TotalPrice = 2342 },
        };
    }
}
