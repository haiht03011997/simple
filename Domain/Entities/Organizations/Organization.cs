
using Domain.Entities.Positions;

namespace Domain.Entities.Organizations
{
    public sealed class Organization : BaseEntity<OrganizationId>
    {
        private readonly List<Position> _positions = new();
        public string Name { get; private set; }
        public IReadOnlyList<Position> Positions => _positions.AsReadOnly();
        private Organization()
        {
        }
        private Organization(string name, List<Position>? positions, OrganizationId? organizationId = null) : base(organizationId ?? new OrganizationId(Guid.NewGuid()))
        {
            Name = name;
            _positions = positions;
        }

        public static Organization Create(string name, List<Position>? positions = null)
        {
            // TODO: enforce invariants
            return new Organization(
                name,
                positions);
        }
        public void Update(string name, List<Position>? updatedPositions = null)
        {
            Name = name;
        }

        public void UpdatePosition(Position updatedPosition)
        {
            var existingPosition = _positions.FirstOrDefault(p => p.Id.Equals(updatedPosition.Id));
            if (existingPosition != null)
            {
                // Update existing position
                existingPosition.UpdateDetails(updatedPosition.Name, updatedPosition.Description);
                existingPosition.UpdateStaff(updatedPosition.StaffPositions.Select(sp => sp.StaffId).ToList());
            }
            else
            {
                // Add new position
                _positions.Add(updatedPosition);
            }
        }
    }
}
