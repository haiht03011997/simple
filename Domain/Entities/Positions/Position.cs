using Domain.Entities.GroupTitles;
using Domain.Entities.StaffPositions;

namespace Domain.Entities.Positions
{
    public class Position : BaseEntity<Guid>
    {
        private readonly List<StaffPosition> _staffPositions = new();
        public string Name { get; private set; }
        public bool? IsManage { get; private set; }
        public string? Description { get; private set; }
        public Guid GroupTitleId { get; private set; }
        public IReadOnlyList<StaffPosition> StaffPositions => _staffPositions;
        public virtual  GroupTitle GroupTitle { get;}
        private Position() { }
        private Position(string name, string? desciption, bool? isManage, Guid groupTitleId, List<StaffPosition>? staffPositions, Guid? positionId = null) : base(positionId ?? Guid.NewGuid())
        {
            Name = name;
            Description = desciption;
            IsManage = isManage;
            GroupTitleId = groupTitleId;
            _staffPositions = staffPositions;
        }
        public static Position Create(string name, string? description, bool? isManage, Guid groupTitleId, List<Guid>? staffIds = null)
        {
            // Create a new position without any staff
            var position = new Position(name, description, isManage, groupTitleId, new List<StaffPosition>());

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

        public void UpdateDetails(string newName, string newDescription, bool? isManage, Guid groupTitleId, bool? isDeleted)
        {
            Name = newName;
            Description = newDescription;
            IsManage = isManage;
            GroupTitleId = groupTitleId;
            MarkDeleted(isDeleted);
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
            var staffPosition = new StaffPosition(this.Id, staffId);
            _staffPositions.Add(staffPosition);
        }
    }
}
