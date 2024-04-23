using Domain.Entities.StaffPositions;
using Domain.Entities.Staffs;
using System.Linq;

namespace Domain.Entities.Positions
{
    public class Position : BaseEntity<PositionId>
    {
        private readonly List<StaffPosition> _staffPositions = new();
        public string Name { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyList<StaffPosition> StaffPositions => _staffPositions;
        private Position() { }
        private Position(string name, string desciption, List<StaffPosition>? staffPositions, PositionId? positionId = null) : base(positionId ?? new PositionId(Guid.NewGuid()))
        {
            Name = name;
            Description = desciption;
            _staffPositions = staffPositions;
        }
        public static Position Create(string name, string description, List<StaffId>? staffIds = null)
        {
            // Create a new position without any staff
            var position = new Position(name, description, new List<StaffPosition>());

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

        public void UpdateDetails(string newName, string newDescription)
        {
            Name = newName;
            Description = newDescription;
        }

        public void UpdateStaff(List<StaffId>? newStaffIds)
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

        private void AddStaff(StaffId staffId)
        {
            var staffPosition = new StaffPosition(this.Id, staffId);
            _staffPositions.Add(staffPosition);
        }
    }
}
