namespace Contracts.Request.Organizations
{
    public class CreatePositionRequest
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public List<Guid>? StaffIds { get; set; }
    }
}
