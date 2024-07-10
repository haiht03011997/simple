namespace Domain.Entities
{
    public abstract class BaseAggregateRoot<TKey> : AuditedEntityBase
    {
        public TKey Id { get; protected set; }
        public bool IsDeleted { get; private set; } = false;
        protected BaseAggregateRoot()
        {
        }

        protected BaseAggregateRoot(TKey id)
        {
            Id = id;
        }

        public void MarkDeleted(bool? isDeleted)
        {
            IsDeleted = isDeleted ?? false;
        }
    }

}
