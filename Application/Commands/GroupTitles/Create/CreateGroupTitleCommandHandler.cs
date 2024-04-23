using Application.Commands.GroupTiles.Create;
using Application.Interfaces.Entities;
using Domain.Entities.GroupTitles;
using MediatR;

namespace Application.Commands.Staffs.Create
{
    internal class CreateGroupTitleCommandHandler : IRequestHandler<CreateGroupTitleCommand>
    {
        private readonly IGroupTitleRepository _groupTitleRepository;

        public CreateGroupTitleCommandHandler(IGroupTitleRepository groupTitleRepository)
        {
            _groupTitleRepository = groupTitleRepository;
        }

        public async Task Handle(CreateGroupTitleCommand request, CancellationToken cancellationToken)
        {
            GroupTitle groupTitle = GroupTitle.Create(request.Name);
            await _groupTitleRepository.AddAsync(groupTitle);
        }
    }
}
