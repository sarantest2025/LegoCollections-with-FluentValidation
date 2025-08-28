using LegoCollections.Data;
using LegoCollections.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace LegoCollections.LegoFigures.Commands;


public record UpdateLegoFiguresCommand(int Id, string Name, string BrickLinkCode, string conditions) : IRequest;

public class UpdateLegoFiguresCommandHandler(LegoDbContext context) : IRequest<UpdateLegoFiguresCommand>
{

    private readonly LegoDbContext _context = context;

    public async Task<Unit> Handle(UpdateLegoFiguresCommand request, CancellationToken cancellationToken)
    {
        var figure = await _context.LegoFigures.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);
        figure.Name = request.Name;
        figure.BrickLinkCode = request.BrickLinkCode;
        figure.Condition = request.conditions;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
