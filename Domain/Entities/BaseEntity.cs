namespace Domain.Entities
{
    public abstract class BaseEntity<TKey> : AuditedEntityBase
    {
        public TKey Id { get; protected set; }
        public bool IsDeleted { get; private set; } = false;
        protected BaseEntity()
        {
        }

        protected BaseEntity(TKey id)
        {
            Id = id;
        }

        public void MarkDeleted(bool? isDeleted)
        {
            IsDeleted = isDeleted ?? false;
        }
    }

}
