using Domain.Entities.GroupTitles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class GroupTitleConfiguration : IEntityTypeConfiguration<GroupTitle>
    {
        public void Configure(EntityTypeBuilder<GroupTitle> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
