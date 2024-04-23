using MediatR;

namespace Application.Commands.GroupTiles.Create
{
    public record CreateGroupTitleCommand(string Name) : IRequest;
}
