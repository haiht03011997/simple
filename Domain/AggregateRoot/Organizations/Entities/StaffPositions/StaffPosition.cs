using Domain.Entities.Staffs;

namespace Domain.AggregateRoot.Organizations.Entities.StaffPositions
{
    public class StaffPosition
    {
        public Guid PositionId { get; private set; }

        public Guid StaffId { get; private set; }
        public virtual Staff Staff { get; private set; }
        private StaffPosition() { }
        public StaffPosition(Guid positionId, Guid staffId)
        {
            PositionId = positionId;
            StaffId = staffId;
        }
    }
}
