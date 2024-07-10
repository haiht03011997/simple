using Domain.AggregateRoot.Organizations.Entities.Positions;
using Domain.Enumerations;

namespace Domain.Entities.Organizations
{
    public sealed class Organization : BaseAggregateRoot<Guid>
    {
        private readonly List<Position> _positions = new();
        public string Name { get; private set; }
        public Guid? ParentAdministrativeId { get; private set; }
        public bool? IsSameOrganization { get; private set; }
        public Guid? PIC { get; private set; }
        public IReadOnlyList<Position> Positions => _positions.AsReadOnly();
        private Organization()
        {
        }
        private Organization(string name, Guid? parentAdministrativeId, bool? isSameOrganization,Guid? pIC, List<Position>? positions, Guid? organizationId = null) : base(organizationId ?? Guid.NewGuid())
        {
            Name = name;
            ParentAdministrativeId = parentAdministrativeId;
            IsSameOrganization = isSameOrganization;
            PIC = pIC;
            _positions = positions;
        }

        public static Organization Create(string name, Guid? parentId, bool? isSameOrganization,Guid? pIC, List<Position>? positions = null)
        {
            // TODO: enforce invariants
            return new Organization(
                name,
                parentId,
                isSameOrganization,
                pIC,
                positions);
        }
        public void Update(string name, bool? isSameOrganization)
        {
            Name = name;
            IsSameOrganization = isSameOrganization;
        }

        public void UpdatePosition(Position updatedPosition)
        {
            var existingPosition = _positions.FirstOrDefault(p => p.Id.Equals(updatedPosition.Id));
            if (existingPosition != null)
            {
                // Update existing position
                existingPosition.UpdateDetails(updatedPosition.PostName, updatedPosition.PostType, updatedPosition.IsManager, updatedPosition.IsAccountable);
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
