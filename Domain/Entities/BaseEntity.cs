using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; protected set; }
        public DateTime? CreatedDate { get; private set; }
        public DateTime? LastUpdatedDate { get; private set; }
        public string? CreatedBy { get; private set; }
        public string? LastUpdatedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        protected BaseEntity()
        {
        }

        protected BaseEntity(TKey id)
        {
            Id = id;
            // Initialize dates in constructor if appropriate
            var now = DateTime.UtcNow;
            CreatedDate = now;
            LastUpdatedDate = now;
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

        public void MarkDeleted()
        {
            IsDeleted = true;
        }
    }

}
