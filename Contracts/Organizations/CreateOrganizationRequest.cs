namespace Contracts.Organizations
{
    public class CreateOrganizationRequest
    {
        public required string Name { get; set; }
        public List<CreatePositionRequest>? createPositionRequests { get; set; }
    }
}
