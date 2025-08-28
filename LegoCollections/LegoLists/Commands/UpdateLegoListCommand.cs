using LegoCollections.Data;
using LegoCollections.Models;
using MediatR;
//using LegoCollection.Models;

namespace LegoCollections.LegoLists.Commands;
 
public record UpdateLegoListCommand(int Id, string Name) : IRequest;

public class UpdateLegoListHandler : IRequestHandler<UpdateLegoListCommand>
{
    private readonly LegoDbContext _context;
    public UpdateLegoListHandler(LegoDbContext context) => _context = context;

    public async Task<Unit> Handle(UpdateLegoListCommand request, CancellationToken cancellationToken)
    {
        var list = await _context.LegoLists.FindAsync(request.Id);
        if (list == null) throw new KeyNotFoundException("Liste ikke funnet");
        list.Name = request.Name;
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}