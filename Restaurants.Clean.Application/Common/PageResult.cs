namespace Restaurants.Clean.Application;

public class PageResult<T>
{
    public PageResult(IEnumerable<T> results,int TotalCount,int PageSize,int Pagenum)
    {
        Results = results;
        TotalItemsCount = TotalCount;
        TotalPages = (int)Math.Ceiling(TotalCount /(double)PageSize);
        ItemsFrom = (Pagenum - 1) * PageSize + 1;
        ItemsTo = ItemsFrom + PageSize -1;
    }
    public IEnumerable<T> Results { get; set; }
    public int TotalPages { get; set; }
    public int TotalItemsCount { get; set; }
    public int ItemsFrom { get; set; }
    public int ItemsTo { get; set; }

}
 