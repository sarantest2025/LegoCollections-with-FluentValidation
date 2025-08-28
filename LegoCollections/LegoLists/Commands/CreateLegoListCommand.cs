using MediatR;
//using LegoCollections.DTOs;
using LegoCollections.Models;
using LegoCollections.Data;


namespace LegoCollections.LegoLists.Commands;

    public record CreateLegoListCommand(string Name) : IRequest<int>;

public class CreateLegoListHandler : IRequestHandler<CreateLegoListCommand, int>
{
    private readonly LegoDbContext _context;

    public CreateLegoListHandler(LegoDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateLegoListCommand request, CancellationToken cancellationToken)
    {
        var list = new LegoList { Name = request.Name };
        _context.LegoLists.Add(list);
        await _context.SaveChangesAsync(cancellationToken);
        return list.Id;
    }
}
