using Microsoft.EntityFrameworkCore;

namespace BusinessObjects.Models.DTOs;

public class PaginatedResponse<T>(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
{
    public IReadOnlyCollection<T> Items { get; } = items;
    public int PageNumber { get; } = pageNumber;
    public int TotalPages { get; } = (int)Math.Ceiling(count / (double)pageSize);
    public int TotalCount { get; } = count;

    public static async Task<PaginatedResponse<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginatedResponse<T>(items, count, pageNumber, pageSize);
    }
    public static PaginatedResponse<T> Create(
        IReadOnlyCollection<T> items,
        int totalCount,
        int pageNumber,
        int pageSize)
    {
        return new PaginatedResponse<T>(items, totalCount, pageNumber, pageSize);
    }
}