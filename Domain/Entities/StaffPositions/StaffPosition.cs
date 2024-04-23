using Domain.Entities.Positions;
using Domain.Entities.Staffs;

namespace Domain.Entities.StaffPositions
{
    public class StaffPosition
    {
        public PositionId PositionId { get; private set; }

        public StaffId StaffId { get; private set; }
        public virtual Staff Staff { get; private set; }
        private StaffPosition() { }
        public StaffPosition(PositionId positionId, StaffId staffId) {
            PositionId = positionId;
            StaffId = staffId;
        }
    }
}
