using Domain.AggregateRoot.Organizations.Entities.StaffPositions;
using VPG_QLKH_Organization.Enums;

namespace Domain.AggregateRoot.Organizations.Entities.Positions
{
    public class Position : BaseEntity<Guid>
    {
        private readonly List<StaffPosition> _staffPositions = new();
        public PostType PostType { get; private set; }
        public string PostName { get; private set; }
        public bool? IsManager { get; private set; }
        public bool? IsAccountable { get; private set; }
        public IReadOnlyList<StaffPosition> StaffPositions => _staffPositions;
        private Position() { }
        private Position(string postName, PostType postType, bool? isManager, bool? isAccountable, List<StaffPosition>? staffPositions, Guid? positionId = null) : base(positionId ?? Guid.NewGuid())
        {
            PostName = postName;
            PostType = postType;
            IsAccountable = isManager;
            IsAccountable = isAccountable;
            _staffPositions = staffPositions;
        }
        public static Position Create(string postName, PostType postType, bool? isManager, bool? isAccountable, List<Guid>? staffIds = null)
        {
            // Create a new position without any staff
            var position = new Position(postName, postType, isManager, isAccountable, new List<StaffPosition>());

            // Add each staff member to the position
            if (staffIds is not null && staffIds.Any())
            {
                foreach (var staffId in staffIds)
                {
                    position.AddStaff(staffId);
                }
            }

            return position;
        }

        public void UpdateDetails(string postName, PostType postType, bool? isManager, bool? isAccountable)
        {
            PostName = postName;
            PostType = postType;
            IsManager = isManager;
            IsAccountable = isAccountable;
        }

        public void UpdateStaff(List<Guid>? newStaffIds)
        {
            _staffPositions.Clear();

            if (newStaffIds != null)
            {
                foreach (var staffId in newStaffIds)
                {
                    AddStaff(staffId);
                }
            }
        }

        private void AddStaff(Guid staffId)
        {
            var staffPosition = new StaffPosition(Id, staffId);
            _staffPositions.Add(staffPosition);
        }
    }
}
