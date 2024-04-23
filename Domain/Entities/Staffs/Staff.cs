
namespace Domain.Entities.Staffs
{
    public class Staff : BaseEntity<StaffId>
    {
        public string Name { get; private set; }

        public string Email { get; private set; }
        private Staff() { }
        private Staff(string name, string email):base(new StaffId(Guid.NewGuid()))
        {
            Name = name;
            Email = email;
        }
        public static Staff Create(string name, string email)
        {
            // TODO: enforce invariants
            return new Staff(
                name,
                email);
        }
    }
}
