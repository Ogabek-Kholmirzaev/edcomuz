namespace Expense.Application.Pagination;

public record PaginationRequest(int PageIndex = 1, int PageSize = 10);