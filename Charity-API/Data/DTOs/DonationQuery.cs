using Charity_API.SortingAndPaging;

namespace Charity_API.Data.DTOs
{
    public class DonationQuery : IQueryObj
    {
        public string? SortBy { get; set; }
        public bool? IsSortAscending { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public DateTime? DateOfDonation { get; set; }
        public double? LeftoverAmount { get; set; }
    }
}
