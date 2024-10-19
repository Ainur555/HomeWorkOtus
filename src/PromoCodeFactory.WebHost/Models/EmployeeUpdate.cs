namespace PromoCodeFactory.WebHost.Models
{
    public class EmployeeUpdate
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }

        public int AppliedPromocodesCount { get; init; }
    }
}
