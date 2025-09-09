using MediatR;
using LegoCollections.Models;
using LegoCollections.Data;
using FluentValidation;

namespace LegoCollections.Commands.LegoFigures;

public record CreateLegoFiguresCommand(int LegoListId, string Name, string BrickLinkCode, string Condition) : IRequest<int>;

public class CreateLegoFiguresHandler : IRequestHandler<CreateLegoFiguresCommand, int>
{
    private readonly LegoDbContext _context;
    public CreateLegoFiguresHandler(LegoDbContext context) => _context = context;
 
    public async Task<int> Handle(CreateLegoFiguresCommand request, CancellationToken cancellationToken)
    {
        var figure = new LegoFigure
        {
            LegoListId = request.LegoListId,
            Name = request.Name,
            BrickLinkCode = request.BrickLinkCode,
            Condition = request.Condition
        };
 
        _context.LegoFigures.Add(figure);
        await _context.SaveChangesAsync(cancellationToken);
        return figure.Id;
    }
}


