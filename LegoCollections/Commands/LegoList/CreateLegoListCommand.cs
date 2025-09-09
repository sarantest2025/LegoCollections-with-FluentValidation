using MediatR;
using LegoCollections.Models;
using LegoCollections.Data;

namespace LegoCollections.Commands.LegoLists;

public record CreateLegoListCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string? Id { get; set; }
    public string? UserId { get; set; }
}

public class CreateLegoListCommandHandler(LegoDbContext context) : IRequestHandler<CreateLegoListCommand, int>
{
    private readonly LegoDbContext _context = context;

    public object? UserName { get; set; }

    public async Task<int> Handle(CreateLegoListCommand request, CancellationToken cancellationToken)
    {
        var list = new LegoList { Name = request.Name, UserId = request.UserId ?? string.Empty};
        _context.LegoLists.Add(list);
        await _context.SaveChangesAsync(cancellationToken);
        return list.Id;
    }
}
