namespace Contracts.Responses.Organization
{
    public class GetByIdOrgResponse
    {
        public Guid Id { get; set; }
        public Guid? ParentAdministrativeId { get; set; }
        public required string OrgName { get; set; }
        public bool? IsSameOrganization { get; set; }
        public Guid? PIC { get; set; }
        public List<GetPositionResponse>? OrgPosts { get; set; }
    }

    public class GetPositionResponse
    {
        public Guid Id { get; set; }
        public int PostType { get; set; }
        public required string PostName { get; set; }
        public bool? IsManager { get; set; }
        public bool? IsAccountable { get; set; }
        public List<Guid>? PersonIds { get; set; }
    }
}
