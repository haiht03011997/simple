
namespace Domain.Entities;

public abstract class AuditedEntityBase
{
    public string? CreatedBy { get; private set; }
    public DateTime? CreatedDate { get; private set; }
    public string? LastUpdatedBy { get; private set; }
    public DateTime? LastUpdatedDate { get; private set; }

    protected AuditedEntityBase()
    {
    }

    protected AuditedEntityBase(string createdBy, DateTime? createdDate, string lastUpdatedBy , DateTime? lastUpdatedDate)
    {
        CreatedBy = createdBy;
        CreatedDate = createdDate;
        LastUpdatedBy = lastUpdatedBy;
        LastUpdatedDate = lastUpdatedDate;
    }

    public void SetCreationAudit(string createdBy)
    {
        CreatedBy = createdBy;
        CreatedDate = DateTime.UtcNow;
    }

    public void SetUpdateAudit(string updatedBy)
    {
        LastUpdatedBy = updatedBy;
        LastUpdatedDate = DateTime.UtcNow;
    }
}
