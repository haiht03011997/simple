using Application.Interfaces.Entities;
using Domain.AggregateRoot.Organizations.Entities.Positions;
using Domain.Entities.Organizations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class OrganizationRepository : GenericRepository<Organization, Guid>, IOrganizationRepository 
    {

        public OrganizationRepository(IUnitOfWork context) : base(context)
        {
        }

        public override async Task<Organization> CreateOrUpdateAsync(Organization organization)
        {
            List<Type> entitiesToBeUpdated = new List<Type>();
            entitiesToBeUpdated.Add(typeof(Position));
            return await base.CreateOrUpdateAsync(organization, entitiesToBeUpdated);
        }

        public async Task<Organization?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Organization>().Include(x => x.Positions).ThenInclude(x => x.StaffPositions).ThenInclude(x => x.Staff)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(Organization organization)
        {
            await _context.Set<Organization>().AddAsync(organization);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Organization organization)
        {
            _context.Set<Organization>().Update(organization);
            await _context.SaveChangesAsync();
        }

        public async Task<dynamic> GetGraph()
        {
            var rootGuid = await _context.Set<Organization>()
                .Where(x => x.IsDeleted == false)
                .Where(x => x.ParentAdministrativeId == null)
                .Select(x => x.Id)
                .SingleOrDefaultAsync();
            var root = await GetTreeNode(rootGuid);
            return root;
        }

        private async Task<dynamic> GetTreeNode(Guid nodeId)
        {
            var node = await _context.Set<Organization>()
                .Where(x => x.Id == nodeId && x.IsDeleted == false)
                .Include(x => x.Positions)
                .ThenInclude(x => x.StaffPositions).ThenInclude(x => x.Staff)
                .FirstOrDefaultAsync();

            if (node == null)
                return null;

            var children = await _context.Set<Organization>()
                .Where(x => x.ParentAdministrativeId == nodeId)
                .ToListAsync();

            var childNodes = new List<dynamic>();
            foreach (var child in children)
            {
                var childNode = await GetTreeNode(child.Id);
                childNodes.Add(childNode);
            }

            return new
            {
                OrgName = node.Name,
                Id = node.Id,
                node.IsSameOrganization,
                OrgPosts = node.Positions?.Select(post => new
                {
                    PostName = post.PostName,
                    PostType = post.PostType,
                    IsManager = post.IsManager,
                    IsAccountable = post.IsAccountable,
                    PersonPosts = post.StaffPositions.Select(x => x.Staff.Name),
                    //PersonPosts = (post.OrgPostPersons == null)
                    //            ? null
                    //            : dbContext.Set<PersonAggregateRoot>()
                    //                    .Where(c => post.OrgPostPersons.PersonId.Contains(c.Id))
                    //                    .Select(c => new
                    //                    {
                    //                        PersonName = c.Name
                    //                    })
                    //                    .ToList()
                }),
                Children = childNodes
            };
        }
    }
}
