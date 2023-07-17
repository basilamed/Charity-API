namespace Charity_API.SortingAndPaging
{
    public class IQueryObj
    {
        //sortiranje
        public string? SortBy { get; set; }
        public bool? IsSortAscending { get; set; }
        //paginacija
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
