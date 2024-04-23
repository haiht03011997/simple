
using Domain.Entities.Positions;
using Domain.Enumerations;

namespace Domain.Entities.Organizations
{
    public sealed class Organization : BaseEntity<Guid>
    {
        private readonly List<Position> _positions = new();
        public string Name { get; private set; }
        public Guid? ParentId { get; private set; }
        public CategoryOrganization Category { get; private set; }
        public bool? IsSameLegal { get; private set; }
        public IReadOnlyList<Position> Positions => _positions.AsReadOnly();
        private Organization()
        {
        }
        private Organization(string name, Guid? parentId, bool? isSameLegal, List<Position>? positions, Guid? organizationId = null) : base(organizationId ?? Guid.NewGuid())
        {
            Name = name;
            ParentId = parentId;
            IsSameLegal = isSameLegal;
            _positions = positions;
        }

        public static Organization Create(string name, Guid? parentId, bool? isSameLegal, List<Position>? positions = null)
        {
            // TODO: enforce invariants
            return new Organization(
                name,
                parentId,
                isSameLegal,
                positions);
        }
        public void Update(string name, bool? isSameLegal, bool? isDeleted = false , List<Position>? updatedPositions = null)
        {
            Name = name;
            IsSameLegal = isSameLegal;
            MarkDeleted(isDeleted);
        }

        public void UpdatePosition(Position updatedPosition)
        {
            var existingPosition = _positions.FirstOrDefault(p => p.Id.Equals(updatedPosition.Id));
            if (existingPosition != null)
            {
                // Update existing position
                existingPosition.UpdateDetails(updatedPosition.Name, updatedPosition.Description, updatedPosition.IsManage, updatedPosition.GroupTitleId, updatedPosition.IsDeleted);
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
