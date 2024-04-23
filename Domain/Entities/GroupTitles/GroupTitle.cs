namespace Domain.Entities.GroupTitles
{
    public class GroupTitle : BaseEntity<Guid>
    {
        public string Name { get; private set; }

        private GroupTitle() { }

        private GroupTitle(string name, Guid? groupTitleId = null): base(groupTitleId ?? Guid.NewGuid())
        {
            Name = name;
        }

        public static GroupTitle Create(string name)
        {
            return new GroupTitle(name);
        }
    }
}
