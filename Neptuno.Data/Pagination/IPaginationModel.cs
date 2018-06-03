namespace Neptuno.Data.Pagination
{
    public interface IPaginationModel
    {
        int? CurrentPage { get; set; }
        int? PageSize { get; set; }
        int? TotalItemCount { get; set; }
    }
}
