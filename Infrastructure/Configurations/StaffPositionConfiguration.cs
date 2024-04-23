using Domain.Entities.Positions;
using Domain.Entities.StaffPositions;
using Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class StaffPositionConfiguration : IEntityTypeConfiguration<StaffPosition>
    {
        public void Configure(EntityTypeBuilder<StaffPosition> builder)
        {
            builder.HasKey(sp => new { sp.StaffId, sp.PositionId });

            builder
                .HasOne(x => x.Staff) // Assuming you have a Staff class
                .WithMany()
                .HasForeignKey(sp => sp.StaffId);

            builder
                .HasOne<Position>()
                .WithMany(p => p.StaffPositions!)
                .HasForeignKey(sp => sp.PositionId);
        }
    }
}
